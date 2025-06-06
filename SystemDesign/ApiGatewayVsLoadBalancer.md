# API Gateway vs Load Balancer


| Feature               | API Gateway                                                                                                                                                                 | Load Balancer                                                                                                                                             |
| --------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Primary Purpose**   | Manage, route, and secure API requests.                                                                                                                                     | Distribute network traffic evenly across servers.                                                                                                         |
| **Layer Operated On** | Application Layer (Layer 7)                                                                                                                                                 | Transport Layer (Layer 4) or Application Layer (Layer 7)                                                                                                  |
| **Functionality**     | - Request routing<br>- Authentication & Authorization<br>- Rate limiting & throttling<br>- API composition<br>- Request/response transformation<br>- Logging and monitoring | - Distribute incoming traffic<br>- Health checks<br>- Failover and redundancy<br>- SSL termination (sometimes)<br>- Session persistence (sticky sessions) |
| **Use Case**          | Managing and securing API calls from clients (e.g., microservices, mobile apps).                                                                                            | Balancing load among multiple servers or instances to improve scalability and availability.                                                               |
| **Complexity**        | More complex, handles business logic related to APIs.                                                                                                                       | Simpler, focuses on traffic distribution.                                                                                                                 |
| **Examples**          | Kong, AWS API Gateway, Apigee, NGINX as API Gateway                                                                                                                         | AWS Elastic Load Balancer (ELB), NGINX, HAProxy, F5 Big-IP                                                                                                |
| **Protocol Support**  | HTTP/HTTPS (usually REST, GraphQL)                                                                                                                                          | TCP, UDP, HTTP/HTTPS                                                                                                                                      |
| **Security Features** | Built-in support for OAuth, JWT, API keys, IP whitelisting                                                                                                                  | Basic SSL termination, sometimes ACLs                                                                                                                     |
| **Transformations**   | Can modify requests and responses (e.g., headers, payload)                                                                                                                  | Typically does not modify requests/responses                                                                                                              |
## Summary:
- Load Balancer primarily distributes traffic to ensure no single server is overwhelmed, improving fault tolerance and availability.

- API Gateway acts as a single entry point to APIs, offering additional controls like security, monitoring, and request transformations tailored for APIs.

## API Gateway and Load Balancer
API Gateway (API Server) and Load Balancer are often used together in modern architectures. They serve complementary roles.

How they work together:
1. Load Balancer sits at the front, distributing incoming client requests across multiple instances of the API Gateway (or API servers).

    - This ensures high availability and scalability of the API Gateway itself.

2. API Gateway then processes the incoming requests with features like authentication, routing to appropriate backend services, rate limiting, etc.

3.  After the API Gateway forwards requests to backend services (like microservices), those backend services can also be behind their own load balancers for scaling.

Typical flow: 
```
Client --> Load Balancer --> Multiple API Gateway Instances --> Backend Services (possibly behind their own load balancers)

```