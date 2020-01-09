## Signature generation and validation
All examples imply that you have already generated ssl-rsa key-pair with such command:
```bash
openssl genrsa -out private.pem 2048
```
and extracted public key:
```bash
openssl rsa -in private.pem -pubout > public.pub
```
### General workflow
**Signing:**

Prerequisite:
1. generate private and public key.
2. send public key to remote representative

Process:
1. sign request body with your private key
2. encode signature in base64
3. put result of step 2 into header Signature
4. send request

**Validation of signature:**

Prerequisite: receive and save public key

Process:
1. receive request
2. get value of Signature header
3. decode it from base64
4. check that result of step 3 is valid for combination of this request body and public key
