import boto3
from botocore.exceptions import ClientError
import time
import unittest

class SQSTest(unittest.TestCase):
    def setUp(self):
        # Initialize SQS client and create/get the queue
        self.sqs = boto3.client('sqs', region_name='us-east-1')
        self.queue_name = "TestQueue"
        
        # Create or connect to an existing SQS queue
        try:
            self.queue_url = self.sqs.create_queue(QueueName=self.queue_name)['QueueUrl']
            print(f"Queue '{self.queue_name}' created or already exists.")
        except ClientError as e:
            self.fail(f"Could not create or connect to queue: {e}")

    def test_send_receive_message(self):
        # Define the message to send
        test_message = "Hello, SQS! This is a test message."
        
        # Send the message to the SQS queue
        try:
            send_response = self.sqs.send_message(
                QueueUrl=self.queue_url,
                MessageBody=test_message
            )
            print(f"Message sent with ID: {send_response['MessageId']}")
        except ClientError as e:
            self.fail(f"Failed to send message: {e}")
        
        # Wait for a moment to ensure the message is available in the queue
        time.sleep(1)
        
        # Receive the message from the SQS queue
        try:
            receive_response = self.sqs.receive_message(
                QueueUrl=self.queue_url,
                MaxNumberOfMessages=1,
                WaitTimeSeconds=5
            )
            messages = receive_response.get('Messages', [])
            
            # Check if we received any messages
            self.assertGreater(len(messages), 0, "No messages received from the queue.")
            
            # Get the first message
            received_message = messages[0]
            received_body = received_message['Body']
            
            # Validate that the received message body matches the sent message
            self.assertEqual(received_body, test_message, "Received message does not match the sent message.")
            print("Message received and verified successfully.")
            
            # Delete the message from the queue to clean up
            self.sqs.delete_message(
                QueueUrl=self.queue_url,
                ReceiptHandle=received_message['ReceiptHandle']
            )
        except ClientError as e:
            self.fail(f"Failed to receive message: {e}")

    def tearDown(self):
        # Clean up: Delete the SQS queue after the test
        try:
            self.sqs.delete_queue(QueueUrl=self.queue_url)
            print(f"Queue '{self.queue_name}' deleted.")
        except ClientError as e:
            print(f"Failed to delete queue: {e}")

# Run the test
if __name__ == "__main__":
    unittest.main()
  
# execute 
python sqs_message_automate.py

