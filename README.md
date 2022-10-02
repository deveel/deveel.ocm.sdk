# Deveel OCM SDK

This repository provides a _Software Development Kit (SDK)_ to enable developers the integration of the functions provided by the [Deveel OCM service](https://docs.ocm.deveel.net): please refer to the documentation of the service to obtain more detailed information about its capabilities and scopes, and the low-level set of functions (eg. _API end-points_, _webhooks_), which consist the base for the projects contained in this space.


## Projects

The _Deveel OCM SDK_ is structured in more than one sub-project, to support more than one usage scenario from the consumer side.

| Project                    | Environment(s)          |
|----------------------------|-------------------------|
| [Deveel OCM .NET](/dotnet) | .NET Runtime            |
| [Deveel OCM CLI](/cli)     | Windows / Linux / POSIX |

## Terminology

To avoid any misunderstandings by users when consuming the deliverables of this repository, we would like to clarify the main terminology adopted

* **SDK** - Stands for _Software Development Kit_, that is the assembly of the _client libraries_ and tools specific for a given programming environment (eg. _.NET_, _Java_, _Python_, etc.).
* **Client Library** - Represent a single library for a specific programmig environment, that developers can reference to interface a single service (or in some cases more than one) of the _Deveel OCM_ platform. The development and release processes of libraries are generally separated between themselves, being oriented to a specific target environment.
* **CLI** - Stands for _Command Line Interface_, that is a console application providing an interface to the service, and wrapping up most of the available functions of the service. The orientation of such deliverable is to provide a tool that is abstracted out of the development environment.
* **OpenAPI** - This is an [open specification](https://swagger.io/specification/) adopted by the _Deveel OCM_ service to describe its available APIs. The typical approach by the SDKs is to use these specifications to generate RESTful clients usable to interface the service.

## Service Structure

The current design of the service follows _domain-driven_ principles of design to expose its functions to the consumers, while the SDK provided in this repository makes a groupping of some of these functions, while keeping some others in their original autonomy.

* **Management** - This client domain encompasses the _management_ of a tenant infrastructure (eg. _terminals_, _routes_, _channels_), that enables the subsequent _messaging_ functions of the system
* **Messaging** - From this domain it is possible to produce (aka _send_) or consume (aka _receive_) messages

## Contribute

Contributions to open-source projects, like **Deveel Webhooks**, is generally driven by interest in using the product and services, if they would respect some of the expectations we have to its functions.

The best ways to contribute and improve the quality of this project is by trying it, filing issues, joining in design conversations, and make pull-requests.

Please refer to the [Contributing Guidelines](CONTRIBUTING.md) to receive more details on how you can contribute to this project.

We aim to address most of the questions you might have by providing [documentations](docs/README.md), answering [frequently asked questions](docs/FAQS.md) and following up on issues like bug reports and feature requests.

### Contributors

<a href="https://github.com/deveel/deveel.ocm.sdk/graphs/contributors">
<img src="https://contrib.rocks/image?repo=deveel/deveel.ocm.sdk"/>
</a>

## License Information

This project is released under the [Apache 2 Open-Source Licensing agreement](https://www.apache.org/licenses/LICENSE-2.0).