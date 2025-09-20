# API RATE LIMITER
## Problem Requirements
1. Limit API requests per customer: X requests per Y seconds.
2. Track multiple customers independently.
3. Support headers: X-RateLimit-Limit and X-RateLimit-Remaining.
4. Thread-safe for concurrent requests.
5. In-memory implementation (no external storage).