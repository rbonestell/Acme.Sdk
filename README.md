# Acme.Sdk

Example containerized microservices solution.

This solution uses Docker (`docker-compose`) with a .dcproj project to:
* Containerize WebAPI services (`acme.sdk.api`, `acme.sdk.math`).
* Bundle database container along with solution (`acme.sdk.db`).
* Connect services together with aliases via a [Docker bridge network](https://docs.docker.com/network/bridge/) (`acme.sdk.network`).
  *  Services and DB can be accessed within the `acme.sdk.network` via their network aliases, E.g. `http://acme.sdk.math/api/add`
