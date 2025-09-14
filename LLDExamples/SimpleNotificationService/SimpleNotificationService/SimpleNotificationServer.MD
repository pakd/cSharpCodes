1. Durability (don’t lose messages)
- Persist messages to disk (file, database, or log).
- On restart, reload unprocessed messages from storage.
- Use acknowledgments: a message is only removed after all subscribers process it (or it’s moved to DLQ).

2. Redundancy (high availability)
- Replicate messages to multiple nodes.
- If one node fails, another has a copy (like Kafka’s replication factor).
- Could be simulated with multiple Topic instances that write to the same persistent store.

3. Dead Letter Queue (DLQ)
- Messages that repeatedly fail for a subscriber are sent to a special queue.
- Prevents message loss while not blocking the main queue.