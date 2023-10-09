# REST Services
The REST services relies on the standards of the HTTP protocol. It uses the URL to specify a resource and then the HTTP verbs to determine the operation type. The 4 mostly used verbs are, `GET`, `PUT`, `POST` and `DELETE`. Their meaning can be seen in the table below.

| HTTP Verb | Description                                 |
| --------- | ------------------------------------------- |
| **GET**   | Used for retrieving data from a server.     |
| **PUT**   | Used for updating or replacing existing data.|
| **POST**  | Used for creating new resources on the server.|
| **DELETE**| Used for removing data or resources from the server.|

Please note that in order for the client to work, the server must be started at the same time.

## Single Origin Policy and CORS
When a browser client connects to a server (as is the case here). Then the browser enforces the Single Origin Policy, this means that the browser will not allow data fetched from another "origin" than where the client is running. This is as simple as the protocol, host and port. In this case the ports differ. To loosen the security policy CORS is enabled on the server to allow all connections (this could be restricted to a certain set og ports or hosts if needed).

