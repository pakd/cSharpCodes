
# 🔐 JWT Authentication in REST APIs

## What is JWT?

**JWT (JSON Web Token)** is a secure and compact way to represent information between two parties. It's commonly used for **authentication** and **authorization** in RESTful APIs.

### Structure of a JWT

A JWT consists of **three parts**:

```
xxxxx.yyyyy.zzzzz
```

- **Header** – Algorithm & token type (e.g., HS256)
- **Payload** – User data / claims (e.g., user ID, role)
- **Signature** – Verifies the token is not tampered with

Example:

```
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.
eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkRlZXBhayIsImlhdCI6MTUxNjIzOTAyMn0.
SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c
```

---

## 🔄 JWT Authentication Flow

### 1. User Login

Client sends login credentials to the server:

```http
POST /api/login
Content-Type: application/json

{
  "username": "deepak",
  "password": "password123"
}
```

### 2. Server Responds with JWT

```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6..."
}
```

### 3. Client Stores the Token

- Store the token in `localStorage`, `sessionStorage`, or app memory (securely).

### 4. Access Protected Routes

Client includes the token in the `Authorization` header:

```http
GET /api/profile
Authorization: Bearer <JWT_TOKEN>
```

Server verifies the token and processes the request if valid.

---

## 🔧 Example: Node.js Middleware

```js
const jwt = require('jsonwebtoken');
const SECRET_KEY = 'mysecretkey';

// Generate JWT after successful login
const token = jwt.sign({ userId: 1, role: 'admin' }, SECRET_KEY, { expiresIn: '1h' });

// Middleware to protect routes
function authenticateToken(req, res, next) {
  const authHeader = req.headers['authorization'];
  const token = authHeader && authHeader.split(' ')[1];

  if (!token) return res.sendStatus(401);

  jwt.verify(token, SECRET_KEY, (err, user) => {
    if (err) return res.sendStatus(403);
    req.user = user;
    next();
  });
}
```

---

## ✅ Benefits of Using JWT

- **Stateless** – No need to store session on the server
- **Compact** – Easy to transmit via HTTP headers
- **Secure** – Signed to prevent tampering

---

## ⚠️ Security Tips

- Always use **HTTPS**
- Set **token expiration time** (e.g., 15 min, 1 hour)
- Use **refresh tokens** to extend sessions
- Never store tokens in insecure places (like localStorage on public/shared devices)



## Example JWT Token
```
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.
eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkRlZXBhayIsImlhdCI6MTUxNjIzOTAyMn0.
SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c
```

### Decode Using jwt.io

Paste the token on https://jwt.io/ to see:

 Decoded Header:
 ```
{
  "alg": "HS256",
  "typ": "JWT"
}
```

Decoded Payload (Claims):
```
{
  "sub": "1234567890",
  "name": "Deepak",
  "iat": 1516239022
}
```
