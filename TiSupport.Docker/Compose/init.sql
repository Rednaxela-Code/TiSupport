-- Create Keycloak database and user
CREATE DATABASE keycloak;
CREATE USER keycloak_user WITH ENCRYPTED PASSWORD 'keycloakpassword';
GRANT ALL PRIVILEGES ON DATABASE keycloak TO keycloak_user;

-- Create API database and user
CREATE DATABASE myapidb;
CREATE USER myapi_user WITH ENCRYPTED PASSWORD 'myapipassword';
GRANT ALL PRIVILEGES ON DATABASE myapidb TO myapi_user;

CREATE USER myuser WITH ENCRYPTED PASSWORD 'mypassword';

GRANT ALL PRIVILEGES ON DATABASE keycloak TO myuser;
GRANT ALL PRIVILEGES ON DATABASE myapidb TO myuser;
