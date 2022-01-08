# LCP_Technical
Technical test for LCP Pulse

#What I have done
I have made use of the mediator pattern, through the Mediatr package, to ensure the design is loosely coupled. In conjunction with the use of CQRS, this means that each bit of functionality is self contained and it will not be impacted by changes to other features. 

The persistence and UI would have been in their own projects, which would mean that different technologies could be used with minimal changes to the rest of the application. Each feature is also in its own folder to keep the solution clean.

The UI was neglected in favour of the functionality (I feel I would have spent too long getting a basic UI going, compared to what could be done backend) so I have added a swagger API that can be used to interact with the application. Accessed by localhost:xxxxx/swagger

Some basic validation has been added to the create client handler, with more time this would have been a bit more in depth (for example checking that an existing email address didn't already exist) and also applied to the other handlers.

#Things I would add

I would have added some more unit tests, as well as some integration tests to fully test the application

More validation using fluent validation

Added error handling - currently the application mostly deals with the happy path. But the response object I have added would mean it is fairly simple to return error messages without major changes.

UI


