# Pre-signed URLs and Multipart Upload in AWS S3 and Azure Blob Storage

---

## Pre-signed URLs

What is it?
A Pre-signed URL is a URL that you can generate to grant temporary, secure access to an object in S3 without requiring AWS credentials.

- Anyone with the URL can perform the specified action (e.g., GET, PUT) on the object.
- It expires after a set time.
- Useful for securely sharing files or allowing uploads/downloads without exposing credentials.

Example use cases:
- Allow users to upload files directly to S3 from their browser.
- Share private files temporarily without making them public.

---

## Multipart Upload

What is it?
Multipart Upload allows you to upload a large file as smaller parts, concurrently or sequentially.

- Improves upload speed and reliability.
- If a part fails, you only retry that part, not the entire file.
- After uploading all parts, you complete the upload, and S3 assembles the parts into a single object.

Benefits:
- Efficient handling of large files (multi-GB).
- Resume uploads in case of network issues.

---

## Are these features available in Azure?

Azure Blob Storage equivalent:

| Feature              | AWS S3                                                                         | Azure Blob Storage                                      |
| -------------------- | ------------------------------------------------------------------------------ | ------------------------------------------------------- |
| **Pre-signed URLs**  | Yes — called **Pre-signed URLs** (or Signed URLs) generated via AWS SDK or CLI | Yes — called **Shared Access Signatures (SAS)** URLs    |
| **Multipart Upload** | Yes — Multipart Upload API                                                     | Yes — called **Block Blobs** with **Block Uploads** API |


---

### Azure Shared Access Signatures (SAS)
- SAS tokens provide temporary, delegated access to blobs or containers.
- You can specify permissions (read, write, delete), expiration time, IP range, etc.
- Works similarly to pre-signed URLs in AWS.

### Azure Block Blobs and Multipart Upload
- Azure’s Block Blob lets you upload large blobs as blocks.
- Upload blocks individually (in parallel if you want).
- Commit blocks to assemble the final blob.
- Supports resumable uploads and large file handling.

---
