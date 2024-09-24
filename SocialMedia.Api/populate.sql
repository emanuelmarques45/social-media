USE [SOCIAL_MEDIA]
GO

---- Insert 60 Users with CreatedAt
--INSERT INTO [dbo].[Users] ([Id], [Name], [Email], [EmailConfirmed], [UserName], [Password], [AccessFailedCount], [CreatedAt])
--VALUES
--    ('John Doe', 'john.doe@example.com', 0, 'john.doe', 'password123', 3, GETDATE()),
--    ('Jane Smith', 'jane.smith@example.com', 0, 'jane.smith', 'password456', 3, GETDATE()),
--    ('Alice Johnson', 'alice.johnson@example.com', 0, 'alice.johnson', 'password789', 3, GETDATE()),
--    ('Bob Brown', 'bob.brown@example.com', 0, 'bob.brown', 'password012', 3, GETDATE()),
--    ('Carol White', 'carol.white@example.com', 0, 'carol.white', 'password345', 3, GETDATE()),
--    ('David Green', 'david.green@example.com', 0, 'david.green', 'password678', 3, GETDATE()),
--    ('Eve Black', 'eve.black@example.com', 0, 'eve.black', 'password901', 3, GETDATE()),
--    ('Frank Blue', 'frank.blue@example.com', 0, 'frank.blue', 'password234', 3, GETDATE()),
--    ('Grace Gray', 'grace.gray@example.com', 0, 'grace.gray', 'password567', 3, GETDATE()),
--    ('Hannah Red', 'hannah.red@example.com', 0, 'hannah.red', 'password890', 3, GETDATE()),
--    ('Ivy King', 'ivy.king@example.com', 0, 'ivy.king', 'password1234', 3, GETDATE()),
--    ('James Lee', 'james.lee@example.com', 0, 'james.lee', 'password5678', 3, GETDATE()),
--    ('Laura Turner', 'laura.turner@example.com', 0, 'laura.turner', 'password91011', 3, GETDATE()),
--    ('Mark Adams', 'mark.adams@example.com', 0, 'mark.adams', 'password1213', 3, GETDATE()),
--    ('Nina Scott', 'nina.scott@example.com', 0, 'nina.scott', 'password1415', 3, GETDATE()),
--    ('Oscar Harris', 'oscar.harris@example.com', 0, 'oscar.harris', 'password1617', 3, GETDATE()),
--    ('Paula Miller', 'paula.miller@example.com', 0, 'paula.miller', 'password1819', 3, GETDATE()),
--    ('Quincy Moore', 'quincy.moore@example.com', 0, 'quincy.moore', 'password2021', 3, GETDATE()),
--    ('Rita Nelson', 'rita.nelson@example.com', 0, 'rita.nelson', 'password2223', 3, GETDATE()),
--    ('Sam Patel', 'sam.patel@example.com', 0, 'sam.patel', 'password2425', 3, GETDATE()),
--    ('Tina Rogers', 'tina.rogers@example.com', 0, 'tina.rogers', 'password2627', 3, GETDATE()),
--    ('Ulysses Green', 'ulysses.green@example.com', 0, 'ulysses.green', 'password2829', 3, GETDATE()),
--    ('Vera Adams', 'vera.adams@example.com', 0, 'vera.adams', 'password3031', 3, GETDATE()),
--    ('Will Carter', 'will.carter@example.com', 0, 'will.carter', 'password3233', 3, GETDATE()),
--    ('Xander Lopez', 'xander.lopez@example.com', 0, 'xander.lopez', 'password3435', 3, GETDATE()),
--    ('Yara Brooks', 'yara.brooks@example.com', 0, 'yara.brooks', 'password3637', 3, GETDATE()),
--    ('Zane Cooper', 'zane.cooper@example.com', 0, 'zane.cooper', 'password3839', 3, GETDATE()),
--    ('Alice White', 'alice.white@example.com', 0, 'alice.white', 'password4041', 3, GETDATE()),
--    ('Bob Smith', 'bob.smith@example.com', 0, 'bob.smith', 'password4243', 3, GETDATE()),
--    ('Clara Johnson', 'clara.johnson@example.com', 0, 'clara.johnson', 'password4445', 3, GETDATE()),
--    ('Derek Adams', 'derek.adams@example.com', 0, 'derek.adams', 'password4647', 3, GETDATE()),
--    ('Ella Davis', 'ella.davis@example.com', 0, 'ella.davis', 'password4849', 3, GETDATE()),
--    ('Felix Martin', 'felix.martin@example.com', 0, 'felix.martin', 'password5051', 3, GETDATE()),
--    ('Gina Lewis', 'gina.lewis@example.com', 0, 'gina.lewis', 'password5253', 3, GETDATE()),
--    ('Henry Clark', 'henry.clark@example.com', 0, 'henry.clark', 'password5455', 3, GETDATE()),
--    ('Iris Young', 'iris.young@example.com', 0, 'iris.young', 'password5657', 3, GETDATE()),
--    ('Jake Walker', 'jake.walker@example.com', 0, 'jake.walker', 'password5859', 3, GETDATE()),
--    ('Kimberly Scott', 'kimberly.scott@example.com', 0, 'kimberly.scott', 'password6061', 3, GETDATE()),
--    ('Liam Roberts', 'liam.roberts@example.com', 0, 'liam.roberts', 'password6263', 3, GETDATE()),
--    ('Maya Carter', 'maya.carter@example.com', 0, 'maya.carter', 'password6465', 3, GETDATE()),
--    ('Nolan Green', 'nolan.green@example.com', 0, 'nolan.green', 'password6667', 3, GETDATE()),
--    ('Olivia Lewis', 'olivia.lewis@example.com', 0, 'olivia.lewis', 'password6869', 3, GETDATE()),
--    ('Paul Walker', 'paul.walker@example.com', 0, 'paul.walker', 'password7071', 3, GETDATE()),
--    ('Quinn Scott', 'quinn.scott@example.com', 0, 'quinn.scott', 'password7273', 3, GETDATE()),
--    ('Riley Young', 'riley.young@example.com', 0, 'riley.young', 'password7475', 3, GETDATE()),
--    ('Sophia Martin', 'sophia.martin@example.com', 0, 'sophia.martin', 'password7677', 3, GETDATE()),
--    ('Tyler Jones', 'tyler.jones@example.com', 0, 'tyler.jones', 'password7879', 3, GETDATE()),
--    ('Ursula Clark', 'ursula.clark@example.com', 0, 'ursula.clark', 'password8081', 3, GETDATE()),
--    ('Victor Roberts', 'victor.roberts@example.com', 0, 'victor.roberts', 'password8283', 3, GETDATE()),
--    ('Wendy Adams', 'wendy.adams@example.com', 0, 'wendy.adams', 'password8485', 3, GETDATE()),
--    ('Xena Lewis', 'xena.lewis@example.com', 0, 'xena.lewis', 'password8687', 3, GETDATE()),
--    ('Yvonne Miller', 'yvonne.miller@example.com', 0, 'yvonne.miller', 'password8889', 3, GETDATE()),
--    ('Zachary Davis', 'zachary.davis@example.com', 0, 'zachary.davis', 'password9091', 3, GETDATE()),
--    ('Ava Harris', 'ava.harris@example.com', 0, 'ava.harris', 'password9293', 3, GETDATE()),
--    ('Brian Taylor', 'brian.taylor@example.com', 0, 'brian.taylor', 'password9495', 3, GETDATE()),
--    ('Catherine Moore', 'catherine.moore@example.com', 0, 'catherine.moore', 'password9697', 3, GETDATE()),
--    ('Diana Wilson', 'diana.wilson@example.com', 0, 'diana.wilson', 'password9899', 3, GETDATE()),
--    ('Eric Thompson', 'eric.thompson@example.com', 0, 'eric.thompson', 'password100101', 3, GETDATE()),
--    ('Fiona White', 'fiona.white@example.com', 0, 'fiona.white', 'password102103', 3, GETDATE()),
--    ('George Hall', 'george.hall@example.com', 0, 'george.hall', 'password104105', 3, GETDATE()),
--    ('Hannah Taylor', 'hannah.taylor@example.com', 0, 'hannah.taylor', 'password106107', 3, GETDATE()),
--    ('Ian Scott', 'ian.scott@example.com', 0, 'ian.scott', 'password108109', 3, GETDATE()),
--    ('Julia King', 'julia.king@example.com', 0, 'julia.king', 'password110111', 3, GETDATE());
--GO

--INSERT INTO [dbo].[Post] ([UserId], [Content], [CreatedAt]) VALUES
---- Posts for John Doe
--(1, 'Exploring the world of C# development!', GETDATE()),
--(1, 'Reading about REST APIs in ASP.NET Core.', GETDATE()),
--(1, 'Just finished building my library management system.', GETDATE()),

---- Posts for Jane Smith
--(2, 'Diving into primary constructors for the first time.', GETDATE()),
--(2, 'Loving the power of LINQ in C#.', GETDATE()),
--(2, 'Next step: Database optimizations!', GETDATE()),

---- Posts for Alice Johnson
--(3, 'Thinking about how to handle cascade deletes effectively.', GETDATE()),
--(3, 'Embracing SOLID principles in my current project.', GETDATE()),
--(3, 'Exploring domain-driven design for complex systems.', GETDATE()),

---- Posts for Bob Brown
--(4, 'Just launched my latest app using ASP.NET Core.', GETDATE()),
--(4, 'Unit testing my library system was a challenge.', GETDATE()),
--(4, 'Discussing best practices in C# software architecture.', GETDATE()),

---- Posts for Carol White
--(5, 'Implemented a great validation system in my code.', GETDATE()),
--(5, 'Making progress on the UML diagrams for a client.', GETDATE()),
--(5, 'Started working with entity relationships.', GETDATE()),

---- Posts for David Green
--(6, 'Wondering how to optimize database queries.', GETDATE()),
--(6, 'Creating my first API for a library project.', GETDATE()),
--(6, 'Today’s focus: securing my API endpoints.', GETDATE()),

---- Posts for Eve Black
--(7, 'Learning more about ASP.NET middleware.', GETDATE()),
--(7, 'Trying out primary constructors for the first time!', GETDATE()),
--(7, 'Starting with cascading deletions in my app.', GETDATE()),

---- Posts for Frank Blue
--(8, 'Just integrated logging into my library system.', GETDATE()),
--(8, 'Feeling excited about microservices architecture.', GETDATE()),
--(8, 'Considering event-driven design for my next project.', GETDATE()),

---- Posts for Grace Gray
--(9, 'Finally got the API documentation finished!', GETDATE()),
--(9, 'Considering different options for API authentication.', GETDATE()),
--(9, 'Working through complex object-relational mapping issues.', GETDATE()),

---- Posts for Hannah Red
--(10, 'Struggling with cascade deletes in my database model.', GETDATE()),
--(10, 'Finally finished setting up JWT authentication.', GETDATE()),
--(10, 'Looking into data seeding in C#.', GETDATE()),

---- Posts for Ivy King
--(11, 'Implemented a new caching layer for performance.', GETDATE()),
--(11, 'Created my first REST API with ASP.NET Core.', GETDATE()),
--(11, 'Learning how to structure my microservices.', GETDATE()),

---- Posts for James Lee
--(12, 'Just wrote a new data migration script!', GETDATE()),
--(12, 'Developing a robust system for handling user sessions.', GETDATE()),
--(12, 'Thinking about improving API performance.', GETDATE()),

---- Posts for Laura Turner
--(13, 'Successfully created an automated testing suite.', GETDATE()),
--(13, 'Optimizing the backend for my library management app.', GETDATE()),
--(13, 'Building a more secure role-based system.', GETDATE()),

---- Posts for Mark Adams
--(14, 'Handling data relationships with Entity Framework.', GETDATE()),
--(14, 'Designing a system to manage loans and returns.', GETDATE()),
--(14, 'Exploring cloud deployment options for my library system.', GETDATE()),

---- Posts for Nina Scott
--(15, 'Just integrated Swagger into my API!', GETDATE()),
--(15, 'Building a user authentication flow from scratch.', GETDATE()),
--(15, 'Looking into server-side validation techniques.', GETDATE()),

---- Posts for Oscar Harris
--(16, 'Working on database migration strategies.', GETDATE()),
--(16, 'Exploring async/await to improve app performance.', GETDATE()),
--(16, 'Setting up dependency injection in my project.', GETDATE()),

---- Posts for Paula Miller
--(17, 'Refactoring my codebase for better readability.', GETDATE()),
--(17, 'Investigating domain-specific designs for software.', GETDATE()),
--(17, 'Preparing to deploy my REST API.', GETDATE()),

---- Posts for Quincy Moore
--(18, 'Solved a major bug related to data integrity!', GETDATE()),
--(18, 'Thinking about scaling my system for large datasets.', GETDATE()),
--(18, 'Tuning my SQL queries for performance.', GETDATE()),

---- Posts for Rita Nelson
--(19, 'Just added unit tests to my project!', GETDATE()),
--(19, 'Diving deep into the world of database indexing.', GETDATE()),
--(19, 'Considering cloud-based solutions for storage.', GETDATE()),

---- Posts for Sam Patel
--(20, 'Learning about API rate-limiting.', GETDATE()),
--(20, 'Just designed my first UML diagram for a new system.', GETDATE()),
--(20, 'Implemented API versioning today.', GETDATE()),

---- Posts for Tina Rogers
--(21, 'Just read about how to prevent SQL injection.', GETDATE()),
--(21, 'Started working on API error handling.', GETDATE()),
--(21, 'Refined my database schema for better efficiency.', GETDATE()),

---- Posts for Ulysses Green
--(22, 'Built a real-time notification system.', GETDATE()),
--(22, 'Finally set up my logging service.', GETDATE()),
--(22, 'Looking into implementing OAuth for my app.', GETDATE()),

---- Posts for Vera Adams
--(23, 'Trying to streamline my CI/CD pipeline.', GETDATE()),
--(23, 'Configured Redis for caching my API data.', GETDATE()),
--(23, 'Exploring different ways to scale my app.', GETDATE()),

---- Posts for Will Carter
--(24, 'Integrated with a third-party API successfully!', GETDATE()),
--(24, 'Working on database backup strategies.', GETDATE()),
--(24, 'Exploring containerization with Docker.', GETDATE()),

---- Posts for Tina Rogers
--(25, 'Exploring API security best practices.', GETDATE()),
--(25, 'Built an authentication flow using JWT.', GETDATE()),
--(25, 'Optimizing my query performance with indexes.', GETDATE()),

---- Posts for Ulysses Green
--(26, 'Refining my REST API error handling strategy.', GETDATE()),
--(26, 'Working on a user-friendly pagination system.', GETDATE()),
--(26, 'Started learning about GraphQL.', GETDATE()),

---- Posts for Vera Adams
--(27, 'Implemented caching with Redis for my application.', GETDATE()),
--(27, 'Working through API throttling strategies.', GETDATE()),
--(27, 'Setting up unit tests for my microservices.', GETDATE()),

---- Posts for Will Carter
--(28, 'Exploring new ways to optimize my database schema.', GETDATE()),
--(28, 'Developed a logging system for API monitoring.', GETDATE()),
--(28, 'Refactoring code to follow clean architecture.', GETDATE()),

---- Posts for Xander Lopez
--(29, 'Dealing with concurrency issues in my project.', GETDATE()),
--(29, 'Added a new feature for managing book returns.', GETDATE()),
--(29, 'Focusing on performance improvements for my API.', GETDATE()),

---- Posts for Yara Brooks
--(30, 'Integrating third-party services into my system.', GETDATE()),
--(30, 'Created a robust authentication module.', GETDATE()),
--(30, 'Just implemented role-based access control.', GETDATE()),

---- Posts for Zane Cooper
--(31, 'Optimizing my database queries for scalability.', GETDATE()),
--(31, 'Building an efficient search functionality.', GETDATE()),
--(31, 'Added error handling and logging to my API.', GETDATE()),

---- Posts for Alice White
--(32, 'Exploring database normalization techniques.', GETDATE()),
--(32, 'Thinking about distributed system architecture.', GETDATE()),
--(32, 'Just deployed my app using Docker.', GETDATE()),

---- Posts for Bob Smith
--(33, 'Diving into asynchronous programming in C#.', GETDATE()),
--(33, 'Debugging complex issues in my API.', GETDATE()),
--(33, 'Looking into API response time improvements.', GETDATE()),

---- Posts for Clara Johnson
--(34, 'Successfully integrated a payment gateway.', GETDATE()),
--(34, 'Creating a seamless user experience with my API.', GETDATE()),
--(34, 'Building a comprehensive test suite.', GETDATE()),

---- Posts for Derek Adams
--(35, 'Exploring OAuth 2.0 for secure authentication.', GETDATE()),
--(35, 'Adding a new reporting module to my system.', GETDATE()),
--(35, 'Handling complex business logic with ease.', GETDATE()),

---- Posts for Ella Davis
--(36, 'Setting up real-time notifications in my app.', GETDATE()),
--(36, 'Learning about API rate-limiting.', GETDATE()),
--(36, 'Refactoring for better maintainability.', GETDATE()),

---- Posts for Felix Martin
--(37, 'Dealing with race conditions in my project.', GETDATE()),
--(37, 'Trying to improve API response times.', GETDATE()),
--(37, 'Exploring the use of web sockets for real-time data.', GETDATE()),

---- Posts for Gina Lewis
--(38, 'Implemented a load balancer for my API.', GETDATE()),
--(38, 'Learning about Kubernetes for container orchestration.', GETDATE()),
--(38, 'Just improved security with HTTPS everywhere.', GETDATE()),

---- Posts for Henry Clark
--(39, 'Working on my database indexing strategy.', GETDATE()),
--(39, 'Refactoring old code to follow SOLID principles.', GETDATE()),
--(39, 'Considering cloud-based solutions for scalability.', GETDATE()),

---- Posts for Iris Young
--(40, 'Integrating Elasticsearch for better search functionality.', GETDATE()),
--(40, 'Optimizing my API for mobile clients.', GETDATE()),
--(40, 'Learning more about cloud-native architecture.', GETDATE()),

---- Posts for Jake Walker
--(41, 'Started implementing role-based permissions.', GETDATE()),
--(41, 'Building my first GraphQL API.', GETDATE()),
--(41, 'Looking into service-oriented architecture for my project.', GETDATE()),

---- Posts for Kimberly Scott
--(42, 'Exploring advanced logging techniques.', GETDATE()),
--(42, 'Starting with containerization in Docker.', GETDATE()),
--(42, 'Improving my CI/CD pipeline for faster deployments.', GETDATE()),

---- Posts for Liam Roberts
--(43, 'Refining error handling in my API.', GETDATE()),
--(43, 'Just launched my app in production.', GETDATE()),
--(43, 'Considering message queues for background processing.', GETDATE()),

---- Posts for Maya Carter
--(44, 'Exploring message brokers for distributed systems.', GETDATE()),
--(44, 'Improved API response times with async calls.', GETDATE()),
--(44, 'Handling long-running processes with queues.', GETDATE()),

---- Posts for Nolan Green
--(45, 'Learning about event-driven architecture.', GETDATE()),
--(45, 'Refactoring my application to microservices.', GETDATE()),
--(45, 'Implemented API versioning for backward compatibility.', GETDATE()),

---- Posts for Olivia Lewis
--(46, 'Deployed my app to AWS!', GETDATE()),
--(46, 'Working with DynamoDB for the first time.', GETDATE()),
--(46, 'Improving my CI/CD process with Jenkins.', GETDATE()),

---- Posts for Paul Walker
--(47, 'Starting to work on advanced query optimizations.', GETDATE()),
--(47, 'Learning about NoSQL databases.', GETDATE()),
--(47, 'Refining my API design for better scalability.', GETDATE()),

---- Posts for Quinn Scott
--(48, 'Just built a new feature for batch processing.', GETDATE()),
--(48, 'Exploring Redis for caching large datasets.', GETDATE()),
--(48, 'Dealing with timeouts in my API.', GETDATE()),

---- Posts for Riley Young
--(49, 'Trying out Azure Functions for serverless architecture.', GETDATE()),
--(49, 'Building a robust logging system for production.', GETDATE()),
--(49, 'Exploring API security in a multi-tenant environment.', GETDATE()),

---- Posts for Sophia Martin
--(50, 'Just created my first machine learning model.', GETDATE()),
--(50, 'Improving data ingestion pipelines for large datasets.', GETDATE()),
--(50, 'Learning about neural networks and deep learning.', GETDATE());


--INSERT INTO [dbo].[Comment] ([Content], [PostId], [UserId], [CreatedAt])
--VALUES
--    ('Great post! I completely agree with your points.', 1, 2, GETDATE()),
--    ('Thanks for sharing! Very insightful.', 1, 3, GETDATE()),
--    ('This helped me a lot, thanks!', 2, 4, GETDATE()),
--    ('I have a different perspective on this topic.', 2, 5, GETDATE()),
--    ('Could you elaborate more on this?', 3, 6, GETDATE()),
--    ('Interesting approach, I’ll try it!', 3, 7, GETDATE()),
--    ('I appreciate the detailed explanation.', 4, 8, GETDATE()),
--    ('I’m still confused about some parts, can you clarify?', 4, 9, GETDATE()),
--    ('This is exactly what I was looking for!', 5, 10, GETDATE()),
--    ('Does this work for all cases?', 5, 1, GETDATE()),
--    ('Really helpful content, thank you!', 6, 2, GETDATE()),
--    ('I’ll be applying this in my project.', 6, 3, GETDATE()),
--    ('I disagree with this part, but the rest is good.', 7, 4, GETDATE()),
--    ('I found a similar issue in my project.', 7, 5, GETDATE()),
--    ('Nice work! This is going to help many people.', 8, 6, GETDATE()),
--    ('This could be improved by adding more details.', 8, 7, GETDATE()),
--    ('Do you have any resources for further reading?', 9, 8, GETDATE()),
--    ('Thanks, this clarified some doubts I had.', 9, 9, GETDATE()),
--    ('I’m going to bookmark this!', 10, 10, GETDATE()),
--    ('Would love to see more content like this.', 10, 1, GETDATE()),
--    ('Good point, but I think there’s more to it.', 11, 2, GETDATE()),
--    ('I appreciate the effort you put into this.', 11, 3, GETDATE()),
--    ('I don’t quite agree, but I see where you’re coming from.', 12, 4, GETDATE()),
--    ('I’m learning so much from your posts.', 12, 5, GETDATE()),
--    ('This part really stood out to me.', 13, 6, GETDATE()),
--    ('Do you think this will work in larger projects?', 13, 7, GETDATE()),
--    ('That’s a valid point, I hadn’t considered it before.', 14, 8, GETDATE()),
--    ('This seems like a solid solution.', 14, 9, GETDATE()),
--    ('Thanks for breaking this down so clearly.', 15, 10, GETDATE()),
--    ('I’m trying this out now, thanks!', 15, 1, GETDATE()),
--    ('Great analysis, I’ll apply this to my workflow.', 16, 2, GETDATE()),
--    ('I’m curious about your thoughts on this alternative approach.', 16, 3, GETDATE()),
--    ('This is a game changer!', 17, 4, GETDATE()),
--    ('I’ll be referencing this for future projects.', 17, 5, GETDATE()),
--    ('Very well explained, thanks!', 18, 6, GETDATE()),
--    ('This could save a lot of time.', 18, 7, GETDATE()),
--    ('I didn’t know about this, thanks for sharing!', 19, 8, GETDATE()),
--    ('This is gold, great job!', 19, 9, GETDATE()),
--    ('I’m interested in learning more about this topic.', 20, 10, GETDATE()),
--    ('Your insights are always valuable.', 20, 1, GETDATE()),
--    ('This really changed my perspective.', 21, 2, GETDATE()),
--    ('I’ve been looking for something like this.', 21, 3, GETDATE()),
--    ('I’m excited to try this out!', 22, 4, GETDATE()),
--    ('This is very detailed, thanks!', 22, 5, GETDATE()),
--    ('I have some follow-up questions.', 23, 6, GETDATE()),
--    ('Can you explain why this works this way?', 23, 7, GETDATE()),
--    ('This article saved me so much time.', 24, 8, GETDATE()),
--    ('I’m going to use this in my next project.', 24, 9, GETDATE()),
--    ('That’s a unique way to approach it, I like it!', 25, 10, GETDATE()),
--    ('This is really interesting, I hadn’t thought of it like that.', 25, 1, GETDATE()),
--    ('I’ll have to try this technique.', 26, 2, GETDATE()),
--    ('I’ve shared this with my team.', 26, 3, GETDATE()),
--    ('This is an interesting perspective.', 27, 4, GETDATE()),
--    ('This helped clarify a few things for me.', 27, 5, GETDATE()),
--    ('Thanks for the post! Very informative.', 28, 6, GETDATE()),
--    ('This method seems very effective.', 28, 7, GETDATE()),
--    ('Do you think this would work in other scenarios?', 29, 8, GETDATE()),
--    ('This made my day, thanks!', 29, 9, GETDATE()),
--    ('I’m looking forward to more content like this.', 30, 10, GETDATE()),
--    ('Can you point me to more resources?', 30, 1, GETDATE()),
--    ('This was a great read, very informative.', 31, 2, GETDATE()),
--    ('I’ve learned a lot from this.', 31, 3, GETDATE()),
--    ('This is fantastic advice!', 32, 4, GETDATE()),
--    ('I’ve used something similar in my own project.', 32, 5, GETDATE()),
--    ('Really insightful, thanks!', 33, 6, GETDATE()),
--    ('Can this be adapted for different use cases?', 33, 7, GETDATE()),
--    ('This was a game changer for me.', 34, 8, GETDATE()),
--    ('I appreciate the examples you’ve provided.', 34, 9, GETDATE()),
--    ('This made the process so much easier for me.', 35, 10, GETDATE()),
--    ('This content is always on point!', 35, 1, GETDATE()),
--    ('I’ve been trying to understand this topic, and this helped a lot.', 36, 2, GETDATE()),
--    ('This technique is very useful.', 36, 3, GETDATE()),
--    ('Do you have more examples like this?', 37, 4, GETDATE()),
--    ('I’m going to implement this ASAP.', 37, 5, GETDATE()),
--    ('This was super helpful, thanks!', 38, 6, GETDATE()),
--    ('I’ve bookmarked this for future reference.', 38, 7, GETDATE()),
--    ('This really clears things up.', 39, 8, GETDATE()),
--    ('Great breakdown of the process.', 39, 9, GETDATE()),
--    ('This is just what I needed!', 40, 10, GETDATE()),
--    ('Can you explain the rationale behind this?', 40, 1, GETDATE()),
--    ('This has been very informative.', 41, 2, GETDATE()),
--    ('I’ll definitely be using this approach.', 41, 3, GETDATE()),
--    ('Very useful content, thank you!', 42, 4, GETDATE()),
--    ('I’ll be using this in my workflow.', 42, 5, GETDATE()),
--    ('This makes things so much simpler!', 43, 6, GETDATE()),
--    ('I’ll definitely recommend this to others.', 43, 7, GETDATE()),
--    ('This was exactly what I was looking for.', 44, 8, GETDATE()),
--    ('This method is really efficient!', 44, 9, GETDATE()),
--    ('This clarified so many things for me.', 45, 10, GETDATE()),
--    ('I’ll be trying this out soon.', 45, 1, GETDATE()),
--    ('This is a great solution.', 46, 2, GETDATE()),
--    ('I’m excited to see more content like this.', 46, 3, GETDATE()),
--    ('This is a very innovative approach.', 47, 4, GETDATE()),
--    ('Thanks for the post, I’ve learned a lot.', 47, 5, GETDATE()),
--    ('This is a fantastic resource!', 48, 6, GETDATE()),
--    ('I’ll be applying this to my work immediately.', 48, 7, GETDATE()),
--    ('Thanks for the detailed explanation.', 49, 8, GETDATE()),
--    ('This is a great method!', 49, 9, GETDATE()),
--    ('I appreciate the example you provided.', 50, 10, GETDATE()),
--    ('I’ll try this approach.', 50, 1, GETDATE()),
--    ('This content is really useful.', 51, 2, GETDATE()),
--    ('I’ll be applying this to my work.', 51, 3, GETDATE()),
--    ('This article clarified a lot for me.', 52, 4, GETDATE()),
--    ('I found this really helpful.', 52, 5, GETDATE()),
--    ('Thanks for the tips!', 53, 6, GETDATE()),
--    ('This process seems really efficient.', 53, 7, GETDATE()),
--    ('I’ll have to give this a try.', 54, 8, GETDATE()),
--    ('This was an eye-opener for me.', 54, 9, GETDATE()),
--    ('Can’t wait to try this out!', 55, 10, GETDATE()),
--    ('Do you have more examples of this?', 55, 1, GETDATE()),
--    ('This has made my work so much easier.', 56, 2, GETDATE()),
--    ('I appreciate the insight you’ve provided.', 56, 3, GETDATE()),
--    ('This will definitely improve my workflow.', 57, 4, GETDATE()),
--    ('I’ve been looking for a solution like this.', 57, 5, GETDATE()),
--    ('This approach seems really useful.', 58, 6, GETDATE()),
--    ('Thanks for providing such a clear explanation.', 58, 7, GETDATE()),
--    ('I’m going to try this out in my next project.', 59, 8, GETDATE()),
--    ('This will save me a lot of time!', 59, 9, GETDATE()),
--    ('Thanks for the breakdown of the steps.', 60, 10, GETDATE()),
--    ('This content is very informative.', 60, 1, GETDATE()),
--    ('I’ve learned a lot from this post.', 61, 2, GETDATE()),
--    ('I’m going to share this with my team.', 61, 3, GETDATE()),
--    ('Thanks for putting this together.', 62, 4, GETDATE()),
--    ('This method is really effective.', 62, 5, GETDATE()),
--    ('I’ll be trying this out soon.', 63, 6, GETDATE()),
--    ('I’ll be incorporating this into my process.', 63, 7, GETDATE()),
--    ('This is such a helpful resource.', 64, 8, GETDATE()),
--    ('I’m excited to implement this.', 64, 9, GETDATE()),
--    ('I really appreciate the clarity of your explanation.', 65, 10, GETDATE()),
--    ('This is a really useful tip.', 65, 1, GETDATE()),
--    ('I’ll be using this in my future projects.', 66, 2, GETDATE()),
--    ('This has saved me so much time.', 66, 3, GETDATE()),
--    ('Thanks for sharing your experience.', 67, 4, GETDATE()),
--    ('This approach is really interesting.', 67, 5, GETDATE()),
--    ('I’m going to give this a try.', 68, 6, GETDATE()),
--    ('This process seems really efficient.', 68, 7, GETDATE()),
--    ('I’ve been struggling with this, thanks for the help.', 69, 8, GETDATE()),
--    ('This method makes everything much simpler.', 69, 9, GETDATE()),
--    ('I’ll be following this technique from now on.', 70, 10, GETDATE()),
--    ('This was really helpful, thanks!', 70, 1, GETDATE()),
--    ('I can’t wait to try this out.', 71, 2, GETDATE()),
--    ('I’ve bookmarked this for future reference.', 71, 3, GETDATE()),
--    ('This clarified a lot for me.', 72, 4, GETDATE()),
--    ('Thanks for providing such a detailed explanation.', 72, 5, GETDATE()),
--    ('This method is going to change how I work.', 73, 6, GETDATE()),
--    ('I’ll definitely be using this in my project.', 73, 7, GETDATE()),
--    ('This was exactly what I needed!', 74, 8, GETDATE()),
--    ('I appreciate the examples you’ve shared.', 74, 9, GETDATE()),
--    ('This is a really insightful post.', 75, 10, GETDATE()),
--    ('I’m looking forward to implementing this.', 75, 1, GETDATE()),
--    ('This technique seems really effective.', 76, 2, GETDATE()),
--    ('I’ll be applying this in my next project.', 76, 3, GETDATE()),
--    ('This has cleared up a lot of confusion for me.', 77, 4, GETDATE()),
--    ('I’m going to start using this technique.', 77, 5, GETDATE()),
--    ('Thanks for the great explanation!', 78, 6, GETDATE()),
--    ('This is really useful information.', 78, 7, GETDATE()),
--    ('This method is going to save me so much time.', 79, 8, GETDATE()),
--    ('I appreciate the detailed steps you’ve provided.', 79, 9, GETDATE()),
--    ('I’ll be trying this out in my workflow.', 80, 10, GETDATE()),
--    ('This is a very helpful resource!', 80, 1, GETDATE()),
--    ('I’ll definitely recommend this to my team.', 81, 2, GETDATE()),
--    ('This article was really informative.', 81, 3, GETDATE()),
--    ('Thanks for sharing this technique.', 82, 4, GETDATE()),
--    ('I’m looking forward to using this in my next project.', 82, 5, GETDATE()),
--    ('This post has helped me a lot.', 83, 6, GETDATE()),
--    ('I’m excited to implement this in my work.', 83, 7, GETDATE()),
--    ('This content is very well-written.', 84, 8, GETDATE()),
--    ('Thanks for the clear and concise explanation.', 84, 9, GETDATE()),
--    ('I’m going to start using this technique in my projects.', 85, 10, GETDATE()),
--    ('This method seems really effective for my use case.', 85, 1, GETDATE()),
--    ('I’ll definitely be following this advice.', 86, 2, GETDATE()),
--    ('I’ve learned a lot from this post.', 86, 3, GETDATE()),
--    ('This is really valuable information.', 87, 4, GETDATE()),
--    ('I’m going to share this with my colleagues.', 87, 5, GETDATE()),
--    ('Thanks for the insights!', 88, 6, GETDATE()),
--    ('This is a great approach, I’ll be using it.', 88, 7, GETDATE()),
--    ('I’ll be applying this in my next project.', 89, 8, GETDATE()),
--    ('This has made things a lot clearer for me.', 89, 9, GETDATE()),
--    ('I really appreciate the practical examples.', 90, 10, GETDATE()),
--    ('This is exactly what I was looking for.', 90, 1, GETDATE()),
--    ('Thanks for the great explanation.', 91, 2, GETDATE()),
--    ('This is a really useful technique.', 91, 3, GETDATE()),
--    ('I’ll be using this in my workflow.', 92, 4, GETDATE()),
--    ('This content is very insightful.', 92, 5, GETDATE()),
--    ('I appreciate the effort you’ve put into this.', 93, 6, GETDATE()),
--    ('This method has saved me a lot of time.', 93, 7, GETDATE()),
--    ('I’ll be trying this out soon.', 94, 8, GETDATE()),
--    ('This is going to make a big difference in my work.', 94, 9, GETDATE()),
--    ('Thanks for the clear explanation!', 95, 10, GETDATE()),
--    ('I’m excited to start using this.', 95, 1, GETDATE()),
--    ('This post has been very helpful.', 96, 2, GETDATE()),
--    ('I’ll be referencing this in my future projects.', 96, 3, GETDATE());

--INSERT INTO [dbo].[Likes] ([PostId], [UserId], [CreatedAt])
--VALUES
--    (1, 2, GETDATE()), 
--    (1, 3, GETDATE()), 
--    (2, 4, GETDATE()), 
--    (2, 5, GETDATE()), 
--    (3, 6, GETDATE()), 
--    (3, 7, GETDATE()), 
--    (4, 8, GETDATE()), 
--    (4, 9, GETDATE()), 
--    (5, 10, GETDATE()), 
--    (5, 1, GETDATE()), 
--    (6, 2, GETDATE()), 
--    (6, 3, GETDATE()), 
--    (7, 4, GETDATE()), 
--    (7, 5, GETDATE()), 
--    (8, 6, GETDATE()), 
--    (8, 7, GETDATE()), 
--    (9, 8, GETDATE()), 
--    (9, 9, GETDATE()), 
--    (10, 10, GETDATE()), 
--    (10, 1, GETDATE()), 
--    (11, 2, GETDATE()), 
--    (11, 3, GETDATE()), 
--    (12, 4, GETDATE()), 
--    (12, 5, GETDATE()), 
--    (13, 6, GETDATE()), 
--    (13, 7, GETDATE()), 
--    (14, 8, GETDATE()), 
--    (14, 9, GETDATE()), 
--    (15, 10, GETDATE()), 
--    (15, 1, GETDATE()), 
--    (16, 2, GETDATE()), 
--    (16, 3, GETDATE()), 
--    (17, 4, GETDATE()), 
--    (17, 5, GETDATE()), 
--    (18, 6, GETDATE()), 
--    (18, 7, GETDATE()), 
--    (19, 8, GETDATE()), 
--    (19, 9, GETDATE()), 
--    (20, 10, GETDATE()), 
--    (20, 1, GETDATE()), 
--    (21, 2, GETDATE()), 
--    (21, 3, GETDATE()), 
--    (22, 4, GETDATE()), 
--    (22, 5, GETDATE()), 
--    (23, 6, GETDATE()), 
--    (23, 7, GETDATE()), 
--    (24, 8, GETDATE()), 
--    (24, 9, GETDATE()), 
--    (25, 10, GETDATE()), 
--    (25, 1, GETDATE()), 
--    (26, 2, GETDATE()), 
--    (26, 3, GETDATE()), 
--    (27, 4, GETDATE()), 
--    (27, 5, GETDATE()), 
--    (28, 6, GETDATE()), 
--    (28, 7, GETDATE()), 
--    (29, 8, GETDATE()), 
--    (29, 9, GETDATE()), 
--    (30, 10, GETDATE()), 
--    (30, 1, GETDATE()), 
--    (31, 2, GETDATE()), 
--    (31, 3, GETDATE()), 
--    (32, 4, GETDATE()), 
--    (32, 5, GETDATE()), 
--    (33, 6, GETDATE()), 
--    (33, 7, GETDATE()), 
--    (34, 8, GETDATE()), 
--    (34, 9, GETDATE()), 
--    (35, 10, GETDATE()), 
--    (35, 1, GETDATE()), 
--    (36, 2, GETDATE()), 
--    (36, 3, GETDATE()), 
--    (37, 4, GETDATE()), 
--    (37, 5, GETDATE()), 
--    (38, 6, GETDATE()), 
--    (38, 7, GETDATE()), 
--    (39, 8, GETDATE()), 
--    (39, 9, GETDATE()), 
--    (40, 10, GETDATE()), 
--    (40, 1, GETDATE()), 
--    (41, 2, GETDATE()), 
--    (41, 3, GETDATE()), 
--    (42, 4, GETDATE()), 
--    (42, 5, GETDATE()), 
--    (43, 6, GETDATE()), 
--    (43, 7, GETDATE()), 
--    (44, 8, GETDATE()), 
--    (44, 9, GETDATE()), 
--    (45, 10, GETDATE()), 
--    (45, 1, GETDATE()), 
--    (46, 2, GETDATE()), 
--    (46, 3, GETDATE()), 
--    (47, 4, GETDATE()), 
--    (47, 5, GETDATE()), 
--    (48, 6, GETDATE()), 
--    (48, 7, GETDATE()), 
--    (49, 8, GETDATE()), 
--    (49, 9, GETDATE()), 
--    (50, 10, GETDATE()), 
--    (50, 1, GETDATE());

INSERT INTO [dbo].[Users] ([Id], [Name], [Email], [EmailConfirmed], [UserName], [PasswordHash], [AccessFailedCount], [CreatedAt])
VALUES
    ('1A2B3C4D-5E6F-7G8H-9I0J-K1L2M3N4O5P6', 'John Doe', 'john.doe@example.com', 0, 'john.doe', 'password123', 3, GETDATE()),
    ('2B3C4D5E-6F7G-8H9I-0J1K-L2M3N4O5P6Q', 'Jane Smith', 'jane.smith@example.com', 0, 'jane.smith', 'password456', 3, GETDATE()),
    ('3C4D5E6F-7G8H-9I0J-K1L2-M3N4O5P6Q7R', 'Alice Johnson', 'alice.johnson@example.com', 0, 'alice.johnson', 'password789', 3, GETDATE()),
    ('4D5E6F7G-8H9I-0J1K-L2M3-N4O5P6Q7R8S', 'Bob Brown', 'bob.brown@example.com', 0, 'bob.brown', 'password012', 3, GETDATE()),
    ('5E6F7G8H-9I0J-K1L2-M3N4-O5P6Q7R8S9T', 'Carol White', 'carol.white@example.com', 0, 'carol.white', 'password345', 3, GETDATE()),
    ('6F7G8H9I-0J1K-L2M3-N4O5-P6Q7R8S9T0U', 'David Green', 'david.green@example.com', 0, 'david.green', 'password678', 3, GETDATE()),
    ('7G8H9I0J-1K2L-M3N4-O5P6-Q7R8S9T0U1V', 'Eve Black', 'eve.black@example.com', 0, 'eve.black', 'password901', 3, GETDATE()),
    ('8H9I0J1K-2L3M-N4O5-P6Q7-R8S9T0U1V2W', 'Frank Blue', 'frank.blue@example.com', 0, 'frank.blue', 'password234', 3, GETDATE()),
    ('9I0J1K2L-3M4N-O5P6-Q7R8-S9T0U1V2W3X', 'Grace Gray', 'grace.gray@example.com', 0, 'grace.gray', 'password567', 3, GETDATE()),
    ('0J1K2L3M-4N5O-P6Q7-R8S9-T0U1V2W3X4Y', 'Hannah Red', 'hannah.red@example.com', 0, 'hannah.red', 'password890', 3, GETDATE()),
    ('1K2L3M4N-5O6P-Q7R8-S9T0-U1V2W3X4Y5Z', 'Ivy King', 'ivy.king@example.com', 0, 'ivy.king', 'password1234', 3, GETDATE()),
    ('2L3M4N5O-6P7Q-R8S9-T0U1-V2W3X4Y5Z6A', 'James Lee', 'james.lee@example.com', 0, 'james.lee', 'password5678', 3, GETDATE()),
    ('3M4N5O6P-7Q8R-S9T0-U1V2-W3X4Y5Z6A7B', 'Laura Turner', 'laura.turner@example.com', 0, 'laura.turner', 'password91011', 3, GETDATE()),
    ('4N5O6P7Q-8R9S-T0U1-V2W3-X4Y5Z6A7B8C', 'Mark Adams', 'mark.adams@example.com', 0, 'mark.adams', 'password1213', 3, GETDATE()),
    ('5O6P7Q8R-9S0T-U1V2-W3X4-Y5Z6A7B8C9D', 'Nina Scott', 'nina.scott@example.com', 0, 'nina.scott', 'password1415', 3, GETDATE()),
    ('6P7Q8R9S-0T1U-V2W3-X4Y5-Z6A7B8C9D0E', 'Oscar Harris', 'oscar.harris@example.com', 0, 'oscar.harris', 'password1617', 3, GETDATE()),
    ('7Q8R9S0T-1U2V-W3X4-Y5Z6-A7B8C9D0E1F', 'Paula Miller', 'paula.miller@example.com', 0, 'paula.miller', 'password1819', 3, GETDATE()),
    ('8R9S0T1U-2V3W-X4Y5-Z6A7-B8C9D0E1F2G', 'Quincy Moore', 'quincy.moore@example.com', 0, 'quincy.moore', 'password2021', 3, GETDATE()),
    ('9S0T1U2V-3W4X-Y5Z6-A7B8-C9D0E1F2G3H', 'Rita Nelson', 'rita.nelson@example.com', 0, 'rita.nelson', 'password2223', 3, GETDATE()),
    ('0T1U2V3W-4X5Y-Z6A7-B8C9-D0E1F2G3H4I', 'Sam Patel', 'sam.patel@example.com', 0, 'sam.patel', 'password2425', 3, GETDATE()),
    ('1U2V3W4X-5Y6Z-A7B8-C9D0-E1F2G3H4I5J', 'Tina Rogers', 'tina.rogers@example.com', 0, 'tina.rogers', 'password2627', 3, GETDATE()),
    ('2V3W4X5Y-6Z7A-B8C9-D0E1-F2G3H4I5J6K', 'Ulysses Green', 'ulysses.green@example.com', 0, 'ulysses.green', 'password2829', 3, GETDATE()),
    ('3W4X5Y6Z-7A8B-C9D0-E1F2-G3H4I5J6K7L', 'Vera Adams', 'vera.adams@example.com', 0, 'vera.adams', 'password3031', 3, GETDATE()),
    ('4X5Y6Z7A-8B9C-D0E1-F2G3-H4I5J6K7L8M', 'Will Carter', 'will.carter@example.com', 0, 'will.carter', 'password3233', 3, GETDATE()),
    ('5Y6Z7A8B-9C0D-E1F2-G3H4-I5J6K7L8M9N', 'Xander Lopez', 'xander.lopez@example.com', 0, 'xander.lopez', 'password3435', 3, GETDATE()),
    ('6Z7A8B9C-0D1E-F2G3-H4I5-J6K7L8M9N0O', 'Yara Brooks', 'yara.brooks@example.com', 0, 'yara.brooks', 'password3637', 3, GETDATE()),
    ('7A8B9C0D-1E2F-G3H4-I5J6-K7L8M9N0O1P', 'Zane Cooper', 'zane.cooper@example.com', 0, 'zane.cooper', 'password3839', 3, GETDATE()),
    ('8B9C0D1E-2F3G-H4I5-J6K7-L8M9N0O1P2Q', 'Alice White', 'alice.white@example.com', 0, 'alice.white', 'password4041', 3, GETDATE()),
    ('9C0D1E2F-3G4H-I5J6-K7L8-M9N0O1P2Q3R', 'Bob Smith', 'bob.smith@example.com', 0, 'bob.smith', 'password4243', 3, GETDATE()),
        ('0D1E2F3G-4H5I-J6K7-L8M9-N0O1P2Q3R4S', 'Clara Johnson', 'clara.johnson@example.com', 0, 'clara.johnson', 'password4445', 3, GETDATE()),
    ('1E2F3G4H-5I6J-K7L8-M9N0-O1P2Q3R4S5T', 'Derek Adams', 'derek.adams@example.com', 0, 'derek.adams', 'password4647', 3, GETDATE()),
    ('2F3G4H5I-6J7K-L8M9-N0O1-P2Q3R4S5T6U', 'Ella Davis', 'ella.davis@example.com', 0, 'ella.davis', 'password4849', 3, GETDATE()),
    ('3G4H5I6J-7K8L-M9N0-O1P2-Q3R4S5T6U7V', 'Felix Martin', 'felix.martin@example.com', 0, 'felix.martin', 'password5051', 3, GETDATE()),
    ('4H5I6J7K-8L9M-N0O1-P2Q3-R4S5T6U7V8W', 'Gina Lewis', 'gina.lewis@example.com', 0, 'gina.lewis', 'password5253', 3, GETDATE()),
    ('5I6J7K8L-9M0N-O1P2-Q3R4-S5T6U7V8W9X', 'Henry Clark', 'henry.clark@example.com', 0, 'henry.clark', 'password5455', 3, GETDATE()),
    ('6J7K8L9M-0N1O-P2Q3-R4S5-T6U7V8W9X0Y', 'Iris Young', 'iris.young@example.com', 0, 'iris.young', 'password5657', 3, GETDATE()),
    ('7K8L9M0N-1O2P-Q3R4-S5T6-U7V8W9X0Y1Z', 'Jake Walker', 'jake.walker@example.com', 0, 'jake.walker', 'password5859', 3, GETDATE()),
    ('8L9M0N1O-2P3Q-R4S5-T6U7-V8W9X0Y1Z2A', 'Kimberly Scott', 'kimberly.scott@example.com', 0, 'kimberly.scott', 'password6061', 3, GETDATE()),
    ('9M0N1O2P-3Q4R-S5T6-U7V8-W9X0Y1Z2A3B', 'Liam Roberts', 'liam.roberts@example.com', 0, 'liam.roberts', 'password6263', 3, GETDATE()),
    ('0N1O2P3Q-4R5S-T6U7-V8W9-X0Y1Z2A3B4C', 'Maya Carter', 'maya.carter@example.com', 0, 'maya.carter', 'password6465', 3, GETDATE()),
    ('1O2P3Q4R-5S6T-U7V8-W9X0-Y1Z2A3B4C5D', 'Nolan Green', 'nolan.green@example.com', 0, 'nolan.green', 'password6667', 3, GETDATE()),
    ('2P3Q4R5S-6T7U-V8W9-X0Y1-Z2A3B4C5D6E', 'Olivia Lewis', 'olivia.lewis@example.com', 0, 'olivia.lewis', 'password6869', 3, GETDATE()),
    ('3Q4R5S6T-7U8V-W9X0-Y1Z2-A3B4C5D6E7F', 'Paul Walker', 'paul.walker@example.com', 0, 'paul.walker', 'password7071', 3, GETDATE()),
    ('4R5S6T7U-8V9W-X0Y1-Z2A3-B4C5D6E7F8G', 'Quinn Scott', 'quinn.scott@example.com', 0, 'quinn.scott', 'password7273', 3, GETDATE()),
    ('5S6T7U8V-9W0X-Y1Z2-A3B4-C5D6E7F8G9H', 'Riley Young', 'riley.young@example.com', 0, 'riley.young', 'password7475', 3, GETDATE()),
    ('6T7U8V9W-0X1Y-Z2A3-B4C5-D6E7F8G9H0I', 'Sophia Martin', 'sophia.martin@example.com', 0, 'sophia.martin', 'password7677', 3, GETDATE()),
    ('7U8V9W0X-1Y2Z-A3B4-C5D6-E7F8G9H0I1J', 'Tyler Jones', 'tyler.jones@example.com', 0, 'tyler.jones', 'password7879', 3, GETDATE()),
    ('8V9W0X1Y-2Z3A-B4C5-D6E7-F8G9H0I1J2K', 'Ursula Clark', 'ursula.clark@example.com', 0, 'ursula.clark', 'password8081', 3, GETDATE()),
    ('9W0X1Y2Z-3A4B-C5D6-E7F8-G9H0I1J2K3L', 'Victor Roberts', 'victor.roberts@example.com', 0, 'victor.roberts', 'password8283', 3, GETDATE()),
    ('0X1Y2Z3A-4B5C-D6E7-F8G9-H0I1J2K3L4M', 'Wendy Adams', 'wendy.adams@example.com', 0, 'wendy.adams', 'password8485', 3, GETDATE()),
    ('1Y2Z3A4B-5C6D-E7F8-G9H0-I1J2K3L4M5N', 'Xena Lewis', 'xena.lewis@example.com', 0, 'xena.lewis', 'password8687', 3, GETDATE()),
    ('2Z3A4B5C-6D7E-F8G9-H0I1-J2K3L4M5N6O', 'Yvonne Miller', 'yvonne.miller@example.com', 0, 'yvonne.miller', 'password8889', 3, GETDATE()),
    ('3A4B5C6D-7E8F-G9H0-I1J2-K3L4M5N6O7P', 'Zachary Davis', 'zachary.davis@example.com', 0, 'zachary.davis', 'password9091', 3, GETDATE()),
    ('4B5C6D7E-8F9G-H0I1-J2K3-L4M5N6O7P8Q', 'Ava Harris', 'ava.harris@example.com', 0, 'ava.harris', 'password9293', 3, GETDATE()),
    ('5C6D7E8F-9G0H-I1J2-K3L4-M5N6O7P8Q9R', 'Brian Taylor', 'brian.taylor@example.com', 0, 'brian.taylor', 'password9495', 3, GETDATE()),
    ('6D7E8F9G-0H1I-J2K3-L4M5-N6O7P8Q9R0S', 'Catherine Moore', 'catherine.moore@example.com', 0, 'catherine.moore', 'password9697', 3, GETDATE()),
    ('7E8F9G0H-1I2J-K3L4-M5N6-O7P8Q9R0S1T', 'Diana Wilson', 'diana.wilson@example.com', 0, 'diana.wilson', 'password9899', 3, GETDATE()),
    ('8F9G0H1I-2J3K-L4M5-N6O7-P8Q9R0S1T2U', 'Eric Thompson', 'eric.thompson@example.com', 0, 'eric.thompson', 'password100101', 3, GETDATE()),
    ('9G0H1I2J-3K4L-M5N6-O7P8-Q9R0S1T2U3V', 'Fiona White', 'fiona.white@example.com', 0, 'fiona.white', 'password102103', 3, GETDATE()),
    ('0H1I2J3K-4L5M-N6O7-P8Q9-R0S1T2U3V4W', 'George Hall', 'george.hall@example.com', 0, 'george.hall', 'password104105', 3, GETDATE()),
    ('1I2J3K4L-5M6N-O7P8-Q9R0-S1T2U3V4W5X', 'Hannah Taylor', 'hannah.taylor@example.com', 0, 'hannah.taylor', 'password106107', 3, GETDATE()),
    ('2J3K4L5M-6N7O-P8Q9-R0S1-T2U3V4W5X6Y', 'Ian Scott', 'ian.scott@example.com', 0, 'ian.scott', 'password108109', 3, GETDATE()),
    ('3K4L5M6N-7O8P-Q9R0-S1T2-U3V4W5X6Y7Z', 'Julia King', 'julia.king@example.com', 0, 'julia.king', 'password110111', 3, GETDATE());
GO

-- Posts for John Doe
INSERT INTO [dbo].[Post] ([UserId], [Content], [CreatedAt]) VALUES
('1A2B3C4D-5E6F-7G8H-9I0J-K1L2M3N4O5P6', 'Exploring the world of C# development!', GETDATE()),
('1A2B3C4D-5E6F-7G8H-9I0J-K1L2M3N4O5P6', 'Reading about REST APIs in ASP.NET Core.', GETDATE()),
('1A2B3C4D-5E6F-7G8H-9I0J-K1L2M3N4O5P6', 'Just finished building my library management system.', GETDATE()),

-- Posts for Jane Smith
('2B3C4D5E-6F7G-8H9I-0J1K-L2M3N4O5P6Q', 'Diving into primary constructors for the first time.', GETDATE()),
('2B3C4D5E-6F7G-8H9I-0J1K-L2M3N4O5P6Q', 'Loving the power of LINQ in C#.', GETDATE()),
('2B3C4D5E-6F7G-8H9I-0J1K-L2M3N4O5P6Q', 'Next step: Database optimizations!', GETDATE()),

-- Posts for Alice Johnson
('3C4D5E6F-7G8H-9I0J-K1L2-M3N4O5P6Q7R', 'Thinking about how to handle cascade deletes effectively.', GETDATE()),
('3C4D5E6F-7G8H-9I0J-K1L2-M3N4O5P6Q7R', 'Embracing SOLID principles in my current project.', GETDATE()),
('3C4D5E6F-7G8H-9I0J-K1L2-M3N4O5P6Q7R', 'Exploring domain-driven design for complex systems.', GETDATE()),

 --Posts for Bob Brown
('4D5E6F7G-8H9I-0J1K-L2M3-N4O5P6Q7R8S', 'Just launched my latest app using ASP.NET Core.', GETDATE()),
('4D5E6F7G-8H9I-0J1K-L2M3-N4O5P6Q7R8S', 'Unit testing my library system was a challenge.', GETDATE()),
('4D5E6F7G-8H9I-0J1K-L2M3-N4O5P6Q7R8S', 'Discussing best practices in C# software architecture.', GETDATE()),

-- Posts for Carol White
('5E6F7G8H-9I0J-K1L2-M3N4-O5P6Q7R8S9T', 'Implemented a great validation system in my code.', GETDATE()),
('5E6F7G8H-9I0J-K1L2-M3N4-O5P6Q7R8S9T', 'Making progress on the UML diagrams for a client.', GETDATE()),
('5E6F7G8H-9I0J-K1L2-M3N4-O5P6Q7R8S9T', 'Started working with entity relationships.', GETDATE()),

-- Posts for David Green
('6F7G8H9I-0J1K-L2M3-N4O5-P6Q7R8S9T0U', 'Wondering how to optimize database queries.', GETDATE()),
('6F7G8H9I-0J1K-L2M3-N4O5-P6Q7R8S9T0U', 'Creating my first API for a library project.', GETDATE()),
('6F7G8H9I-0J1K-L2M3-N4O5-P6Q7R8S9T0U', 'Today’s focus: securing my API endpoints.', GETDATE())

---- Posts for Eve Black
--('7G8H9I0J-K1L2-M3N4-O5P6-Q7R8S9T0U1V', 'Learning more about ASP.NET middleware.', GETDATE()),
--('7G8H9I0J-K1L2-M3N4-O5P6-Q7R8S9T0U1V', 'Trying out primary constructors for the first time!', GETDATE()),
--('7G8H9I0J-K1L2-M3N4-O5P6-Q7R8S9T0U1V', 'Starting with cascading deletions in my app.', GETDATE()),

---- Posts for Frank Blue
--('8H9I0J-K1L2-M3N4-O5P6-Q7R8S9T0U1V2', 'Just integrated logging into my library system.', GETDATE()),
--('8H9I0J-K1L2-M3N4-O5P6-Q7R8S9T0U1V2', 'Feeling excited about microservices architecture.', GETDATE()),
--('8H9I0J-K1L2-M3N4-O5P6-Q7R8S9T0U1V2', 'Considering event-driven design for my next project.', GETDATE()),

---- Posts for Grace Gray
--('9I0J-K1L2-M3N4-O5P6-Q7R8S9T0U1V2-W3X', 'Finally got the API documentation finished!', GETDATE()),
--('9I0J-K1L2-M3N4-O5P6-Q7R8S9T0U1V2-W3X', 'Considering different options for API authentication.', GETDATE()),
--('9I0J-K1L2-M3N4-O5P6-Q7R8S9T0U1V2-W3X', 'Working through complex object-relational mapping issues.', GETDATE()),

---- Posts for Hannah Red
--('0J1K-L2M3-N4O5-P6Q7-R8S9T0U1V2W3-X4Y', 'Struggling with cascade deletes in my database model.', GETDATE()),
--('0J1K-L2M3-N4O5-P6Q7-R8S9T0U1V2W3-X4Y', 'Finally finished setting up JWT authentication.', GETDATE()),
--('0J1K-L2M3-N4O5-P6Q7-R8S9T0U1V2W3-X4Y', 'Looking into data seeding in C#.', GETDATE()),

---- Posts for Ivy King
--('1K2L-M3N4-O5P6-Q7R8-S9T0U1V2W3X4-Y5Z', 'Implemented a new caching layer for performance.', GETDATE()),
--('1K2L-M3N4-O5P6-Q7R8-S9T0U1V2W3X4-Y5Z', 'Created my first REST API with ASP.NET Core.', GETDATE()),
--('1K2L-M3N4-O5P6-Q7R8-S9T0U1V2W3X4-Y5Z', 'Learning how to structure my microservices.', GETDATE()),

---- Posts for James Lee
--('2L3M-N4O5-P6Q7-R8S9-T0U1V2W3X4Y5-Z6A', 'Just wrote a new data migration script!', GETDATE()),
--('2L3M-N4O5-P6Q7-R8S9-T0U1V2W3X4Y5-Z6A', 'Developing a robust system for handling user sessions.', GETDATE()),
--('2L3M-N4O5-P6Q7-R8S9-T0U1V2W3X4Y5-Z6A', 'Thinking about improving API performance.', GETDATE()),

---- Posts for Laura Turner
--('3M4N-O5P6-Q7R8-S9T0-U1V2W3X4Y5Z-6A7B', 'Successfully created an automated testing suite.', GETDATE()),
--('3M4N-O5P6-Q7R8-S9T0-U1V2W3X4Y5Z-6A7B', 'Optimizing the backend for my library management app.', GETDATE()),
--('3M4N-O5P6-Q7R8-S9T0-U1V2W3X4Y5Z-6A7B', 'Building a more secure role-based system.', GETDATE()),

---- Posts for Mark Adams
--('4N5O-P6Q7-R8S9-T0U1-V2W3X4Y5Z6A-7B8C', 'Handling data relationships with Entity Framework.', GETDATE()),
--('4N5O-P6Q7-R8S9-T0U1-V2W3X4Y5Z6A-7B8C', 'Designing a system to manage loans and returns.', GETDATE()),
--('4N5O-P6Q7-R8S9-T0U1-V2W3X4Y5Z6A-7B8C', 'Exploring cloud deployment options for my library system.', GETDATE()),

---- Posts for Nina Scott
--('5O6P-Q7R8-S9T0-U1V2-W3X4Y5Z6A7B-8C9D', 'Just integrated Swagger into my API!', GETDATE()),
--('5O6P-Q7R8-S9T0-U1V2-W3X4Y5Z6A7B-8C9D', 'Building a user authentication flow from scratch.', GETDATE()),
--('5O6P-Q7R8-S9T0-U1V2-W3X4Y5Z6A7B-8C9D', 'Looking into server-side validation techniques.', GETDATE()),

---- Posts for Oscar Harris
--('6P7Q-R8S9-T0U1-V2W3-X4Y5-Z6A7B-8C9D0', 'Working on database migration strategies.', GETDATE()),
--('6P7Q-R8S9-T0U1-V2W3-X4Y5-Z6A7B-8C9D0', 'Exploring async/await to improve app performance.', GETDATE()),
--('6P7Q-R8S9-T0U1-V2W3-X4Y5-Z6A7B-8C9D0', 'Setting up dependency injection in my project.', GETDATE()),

---- Posts for Paula Miller
--('7Q8R-S9T0-U1V2-W3X4-Y5Z6-A7B8C-9D0E1', 'Refactoring my codebase for better readability.', GETDATE()),
--('7Q8R-S9T0-U1V2-W3X4-Y5Z6-A7B8C-9D0E1', 'Investigating domain-specific designs for software.', GETDATE()),
--('7Q8R-S9T0-U1V2-W3X4-Y5Z6-A7B8C-9D0E1', 'Preparing to deploy my REST API.', GETDATE()),

---- Posts for Quincy Moore
--('8R9S-T0U1-V2W3-X4Y5-Z6A7-B8C9-D0E1F', 'Solved a major bug related to data integrity!', GETDATE()),
--('8R9S-T0U1-V2W3-X4Y5-Z6A7-B8C9-D0E1F', 'Thinking about scaling my system for large datasets.', GETDATE()),
--('8R9S-T0U1-V2W3-X4Y5-Z6A7-B8C9-D0E1F', 'Tuning my SQL queries for performance.', GETDATE()),

---- Posts for Rita Nelson
--('9S-T0U1-V2W3-X4Y5-Z6A7-B8C9-D0E1F2', 'Just added unit tests to my project!', GETDATE()),
--('9S-T0U1-V2W3-X4Y5-Z6A7-B8C9-D0E1F2', 'Diving deep into the world of database indexing.', GETDATE()),
--('9S-T0U1-V2W3-X4Y5-Z6A7-B8C9-D0E1F2', 'Considering cloud-based solutions for storage.', GETDATE()),

---- Posts for Sam Patel
--('T0U1-V2W3-X4Y5-Z6A7-B8C9-D0E1-F2G3H', 'Learning about API rate-limiting.', GETDATE()),
--('T0U1-V2W3-X4Y5-Z6A7-B8C9-D0E1-F2G3H', 'Just designed my first UML diagram for a new system.', GETDATE()),
--('T0U1-V2W3-X4Y5-Z6A7-B8C9-D0E1-F2G3H', 'Implemented API versioning today.', GETDATE()),

---- Posts for Tina Rogers
--('U1V2-W3X4-Y5Z6-A7B8-C9D0-E1F2-G3H4I', 'Just read about how to prevent SQL injection.', GETDATE()),
--('U1V2-W3X4-Y5Z6-A7B8-C9D0-E1F2-G3H4I', 'Started working on API error handling.', GETDATE()),
--('U1V2-W3X4-Y5Z6-A7B8-C9D0-E1F2-G3H4I', 'Refined my database schema for better efficiency.', GETDATE()),

---- Posts for Ulysses Green
--('V2W3-X4Y5-Z6A7-B8C9-D0E1-F2G3-H4I5J', 'Built a real-time notification system.', GETDATE()),
--('V2W3-X4Y5-Z6A7-B8C9-D0E1-F2G3-H4I5J', 'Finally set up my logging service.', GETDATE()),
--('V2W3-X4Y5-Z6A7-B8C9-D0E1-F2G3-H4I5J', 'Looking into implementing OAuth for my app.', GETDATE()),

---- Posts for Vera Adams
--('W3X4-Y5Z6-A7B8-C9D0-E1F2-G3H4-I5J6K', 'Trying to streamline my CI/CD pipeline.', GETDATE()),
--('W3X4-Y5Z6-A7B8-C9D0-E1F2-G3H4-I5J6K', 'Configured Redis for caching my API data.', GETDATE()),
--('W3X4-Y5Z6-A7B8-C9D0-E1F2-G3H4-I5J6K', 'Exploring different ways to scale my app.', GETDATE()),

---- Posts for Will Carter
--('X4Y5-Z6A7-B8C9-D0E1-F2G3-H4I5-J6K7L', 'Integrated with a third-party API successfully!', GETDATE()),
--('X4Y5-Z6A7-B8C9-D0E1-F2G3-H4I5-J6K7L', 'Working on database backup strategies.', GETDATE()),
--('X4Y5-Z6A7-B8C9-D0E1-F2G3-H4I5-J6K7L', 'Exploring containerization with Docker.', GETDATE()),

---- Posts for Tina Rogers (duplicate entry with new ID)
--('Y5Z6-A7B8-C9D0-E1F2-G3H4-I5J6-K7L8M', 'Exploring API security best practices.', GETDATE()),
--('Y5Z6-A7B8-C9D0-E1F2-G3H4-I5J6-K7L8M', 'Built an authentication flow using JWT.', GETDATE()),
--('Y5Z6-A7B8-C9D0-E1F2-G3H4-I5J6-K7L8M', 'Optimizing my query performance with indexes.', GETDATE()),

---- Posts for Ulysses Green (duplicate entry with new ID)
--('Z6A7-B8C9-D0E1-F2G3-H4I5-J6K7-L8M9N', 'Refining my REST API error handling strategy.', GETDATE()),
--('Z6A7-B8C9-D0E1-F2G3-H4I5-J6K7-L8M9N', 'Working on a user-friendly pagination system.', GETDATE()),
--('Z6A7-B8C9-D0E1-F2G3-H4I5-J6K7-L8M9N', 'Started learning about GraphQL.', GETDATE()),

---- Posts for Vera Adams (duplicate entry with new ID)
--('A7B8-C9D0-E1F2-G3H4-I5J6-K7L8-M9N0O', 'Implemented caching with Redis for my application.', GETDATE()),
--('A7B8-C9D0-E1F2-G3H4-I5J6-K7L8-M9N0O', 'Working through API throttling strategies.', GETDATE()),
--('A7B8-C9D0-E1F2-G3H4-I5J6-K7L8-M9N0O', 'Setting up unit tests for my microservices.', GETDATE()),

---- Posts for Will Carter (duplicate entry with new ID)
--('B8C9-D0E1-F2G3-H4I5-J6K7-L8M9-N0O1P', 'Exploring new ways to optimize my database schema.', GETDATE()),
--('B8C9-D0E1-F2G3-H4I5-J6K7-L8M9-N0O1P', 'Developed a logging system for API monitoring.', GETDATE()),
--('B8C9-D0E1-F2G3-H4I5-J6K7-L8M9-N0O1P', 'Refactoring code to follow clean architecture.', GETDATE()),

---- Posts for Xander Lopez
--('C9D0-E1F2-G3H4-I5J6-K7L8-M9N0-O1P2Q', 'Dealing with concurrency issues in my project.', GETDATE()),
--('C9D0-E1F2-G3H4-I5J6-K7L8-M9N0-O1P2Q', 'Added a new feature for managing book returns.', GETDATE()),
--('C9D0-E1F2-G3H4-I5J6-K7L8-M9N0-O1P2Q', 'Focusing on performance improvements for my API.', GETDATE()),

---- Posts for Yara Brooks
--('D0E1-F2G3-H4I5-J6K7-L8M9-N0O1-P2Q3R', 'Integrating third-party services into my system.', GETDATE()),
--('D0E1-F2G3-H4I5-J6K7-L8M9-N0O1-P2Q3R', 'Created a robust authentication module.', GETDATE()),
--('D0E1-F2G3-H4I5-J6K7-L8M9-N0O1-P2Q3R', 'Just implemented role-based access control.', GETDATE()),

---- Posts for Zane Cooper
--('E1F2-G3H4-I5J6-K7L8-M9N0-O1P2-Q3R4S', 'Optimizing my database queries for scalability.', GETDATE()),
--('E1F2-G3H4-I5J6-K7L8-M9N0-O1P2-Q3R4S', 'Building an efficient search functionality.', GETDATE()),
--('E1F2-G3H4-I5J6-K7L8-M9N0-O1P2-Q3R4S', 'Added error handling and logging to my API.', GETDATE()),

---- Posts for Alice White
--('F2G3-H4I5-J6K7-L8M9-N0O1-P2Q3-R4S5T', 'Exploring database normalization techniques.', GETDATE()),
--('F2G3-H4I5-J6K7-L8M9-N0O1-P2Q3-R4S5T', 'Thinking about distributed system architecture.', GETDATE()),
--('F2G3-H4I5-J6K7-L8M9-N0O1-P2Q3-R4S5T', 'Just deployed my app using Docker.', GETDATE()),

---- Posts for Bob Smith
--('G3H4-I5J6-K7L8-M9N0-O1P2-Q3R4-S5T6U', 'Diving into asynchronous programming in C#.', GETDATE()),
--('G3H4-I5J6-K7L8-M9N0-O1P2-Q3R4-S5T6U', 'Debugging complex issues in my API.', GETDATE()),
--('G3H4-I5J6-K7L8-M9N0-O1P2-Q3R4-S5T6U', 'Looking into API response time improvements.', GETDATE()),

---- Posts for Clara Johnson
--('H4I5-J6K7-L8M9-N0O1-P2Q3-R4S5-T6U7V', 'Successfully integrated a payment gateway.', GETDATE()),
--('H4I5-J6K7-L8M9-N0O1-P2Q3-R4S5-T6U7V', 'Creating a seamless user experience with my API.', GETDATE()),
--('H4I5-J6K7-L8M9-N0O1-P2Q3-R4S5-T6U7V', 'Building a comprehensive test suite.', GETDATE()),

---- Posts for Derek Adams
--('I5J6-K7L8-M9N0-O1P2-Q3R4-S5T6-U7V8W', 'Exploring OAuth 2.0 for secure authentication.', GETDATE()),
--('I5J6-K7L8-M9N0-O1P2-Q3R4-S5T6-U7V8W', 'Adding a new reporting module to my system.', GETDATE()),
--('I5J6-K7L8-M9N0-O1P2-Q3R4-S5T6-U7V8W', 'Handling complex business logic with ease.', GETDATE()),

---- Posts for Ella Davis
--('J6K7-L8M9-N0O1-P2Q3-R4S5-T6U7-V8W9X', 'Setting up real-time notifications in my app.', GETDATE()),
--('J6K7-L8M9-N0O1-P2Q3-R4S5-T6U7-V8W9X', 'Learning about API rate-limiting.', GETDATE()),
--('J6K7-L8M9-N0O1-P2Q3-R4S5-T6U7-V8W9X', 'Refactoring for better maintainability.', GETDATE()),

---- Posts for Felix Martin
--('K7L8-M9N0-O1P2-Q3R4-S5T6-U7V8-W9X0Y', 'Dealing with race conditions in my project.', GETDATE()),
--('K7L8-M9N0-O1P2-Q3R4-S5T6-U7V8-W9X0Y', 'Trying to improve API response times.', GETDATE()),
--('K7L8-M9N0-O1P2-Q3R4-S5T6-U7V8-W9X0Y', 'Exploring the use of web sockets for real-time data.', GETDATE()),

---- Posts for Gina Lewis
--('L8M9-N0O1-P2Q3-R4S5-T6U7-V8W9-X0Y1Z', 'Implemented a load balancer for my API.', GETDATE()),
--('L8M9-N0O1-P2Q3-R4S5-T6U7-V8W9-X0Y1Z', 'Learning about Kubernetes for container orchestration.', GETDATE()),
--('L8M9-N0O1-P2Q3-R4S5-T6U7-V8W9-X0Y1Z', 'Just improved security with HTTPS everywhere.', GETDATE()),

---- Posts for Henry Clark
--('M9N0-O1P2-Q3R4-S5T6-U7V8-W9X0-Y1Z2A', 'Working on my database indexing strategy.', GETDATE()),
--('M9N0-O1P2-Q3R4-S5T6-U7V8-W9X0-Y1Z2A', 'Refactoring old code to follow SOLID principles.', GETDATE()),
--('M9N0-O1P2-Q3R4-S5T6-U7V8-W9X0-Y1Z2A', 'Considering cloud-based solutions for scalability.', GETDATE()),

---- Posts for Iris Young
--('N0O1-P2Q3-R4S5-T6U7-V8W9-X0Y1-Z2A3B', 'Integrating Elasticsearch for better search functionality.', GETDATE()),
--('N0O1-P2Q3-R4S5-T6U7-V8W9-X0Y1-Z2A3B', 'Optimizing my API for mobile clients.', GETDATE()),
--('N0O1-P2Q3-R4S5-T6U7-V8W9-X0Y1-Z2A3B', 'Learning more about cloud-native architecture.', GETDATE()),

---- Posts for Jake Walker
--('O1P2-Q3R4-S5T6-U7V8-W9X0-Y1Z2-A3B4C', 'Started implementing role-based permissions.', GETDATE()),
--('O1P2-Q3R4-S5T6-U7V8-W9X0-Y1Z2-A3B4C', 'Building my first GraphQL API.', GETDATE()),
--('O1P2-Q3R4-S5T6-U7V8-W9X0-Y1Z2-A3B4C', 'Looking into service-oriented architecture for my project.', GETDATE()),

---- Posts for Kimberly Scott
--('P2Q3-R4S5-T6U7-V8W9-X0Y1-Z2A3-B4C5D', 'Exploring advanced logging techniques.', GETDATE()),
--('P2Q3-R4S5-T6U7-V8W9-X0Y1-Z2A3-B4C5D', 'Starting with containerization in Docker.', GETDATE()),
--('P2Q3-R4S5-T6U7-V8W9-X0Y1-Z2A3-B4C5D', 'Improving my CI/CD pipeline for faster deployments.', GETDATE()),

---- Posts for Liam Roberts
--('Q3R4-S5T6-U7V8-W9X0-Y1Z2-A3B4-C5D6E', 'Refining error handling in my API.', GETDATE()),
--('Q3R4-S5T6-U7V8-W9X0-Y1Z2-A3B4-C5D6E', 'Just launched my app in production.', GETDATE()),
--('Q3R4-S5T6-U7V8-W9X0-Y1Z2-A3B4-C5D6E', 'Considering message queues for background processing.', GETDATE()),

---- Posts for Maya Carter
--('R4S5-T6U7-V8W9-X0Y1-Z2A3-B4C5-D6E7F', 'Exploring message brokers for distributed systems.', GETDATE()),
--('R4S5-T6U7-V8W9-X0Y1-Z2A3-B4C5-D6E7F', 'Building a custom monitoring dashboard.', GETDATE()),
--('R4S5-T6U7-V8W9-X0Y1-Z2A3-B4C5-D6E7F', 'Improving database performance with sharding.', GETDATE()),

---- Posts for Nathaniel Harris
--('S5T6-U7V8-W9X0-Y1Z2-A3B4-C5D6-E7F8G', 'Implementing JWT for user authentication.', GETDATE()),
--('S5T6-U7V8-W9X0-Y1Z2-A3B4-C5D6-E7F8G', 'Building a resilient API with circuit breakers.', GETDATE()),
--('S5T6-U7V8-W9X0-Y1Z2-A3B4-C5D6-E7F8G', 'Optimizing performance with Redis caching.', GETDATE()),

---- Posts for Olivia Wright
--('T6U7-V8W9-X0Y1-Z2A3-B4C5-D6E7-F8G9H', 'Learning about container orchestration with Kubernetes.', GETDATE()),
--('T6U7-V8W9-X0Y1-Z2A3-B4C5-D6E7-F8G9H', 'Implemented JWT authentication for my API.', GETDATE()),
--('T6U7-V8W9-X0Y1-Z2A3-B4C5-D6E7-F8G9H', 'Starting with GraphQL for flexible queries.', GETDATE())
