# Rodrigo de Farias

# Full-stack Assessment - 2.0 - Solution Project Introduction

## What and Why?
For the backend I chose Clean Architecture, CQRS and Mediator Patter.
    

### Clean Architecture
Clean Architecture is a software design philosophy that emphasizes separation of concerns and independence of frameworks, databases, and user interfaces. The main benefits include:

Maintainability: By separating concerns, each part of the system can be developed, tested, and maintained independently.
Testability: Business logic is decoupled from external dependencies, making it easier to write unit tests.
Flexibility: The architecture allows for easy changes and adaptations, such as swapping out databases or UI frameworks without affecting the core business logic.
Scalability: Clean Architecture supports scaling the application by organizing code in a way that is easy to extend.

### CQRS (Command Query Responsibility Segregation)
CQRS is a pattern that separates read and write operations into different models. The main benefits include:

### Performance: 
By separating read and write operations, each can be optimized independently, leading to better performance.
Scalability: Read and write workloads can be scaled independently, allowing for more efficient resource utilization.
Simplicity: Simplifies complex domains by separating the concerns of reading data and modifying data.
Consistency: Helps in achieving eventual consistency in distributed systems by separating the command and query responsibilities.

### Mediator Pattern
The Mediator Pattern is a behavioral design pattern that encapsulates how objects interact with each other, promoting loose coupling. The main benefits include:

### Decoupling: 
Reduces direct dependencies between objects, leading to a more modular and maintainable codebase.
Simplified Communication: Centralizes complex communication logic in a single mediator, making it easier to manage and understand.
Flexibility: Makes it easier to change the interaction between objects without modifying the objects themselves.



# How to run this project?

On the root folder run the following command:
```
    docker compose up
```

# Critique

I would add AutoMapper in a separated file to improve SRP pattern.
If I had more time, I would focus on adding more comprehensive tests to ensure the stability and reliability of the project. Additionally, I would refactor some parts of the code to enhance readability.
I would improve the frontend architecture and the composition of components.

Regarding scaling, the parts that would likely fail first are the database and the API endpoints. As the number of users and posts increases, the database might become a bottleneck due to the increased load, and the API endpoints might struggle to handle the high number of requests.

To scale this product, I would take the following steps:

1. **Database Optimization**: caching, and sharding to improve performance and handle a larger volume of data.
2. **Monitoring and Logging**: Implement robust monitoring and logging to track performance, identify bottlenecks, and quickly address any issues that arise.

By taking these steps, the project would be better equipped to handle growth and provide a reliable experience for a large number of users.


