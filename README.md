# dctrly

Some concepts and assumptions:

DB: PostgreSQL with code first approach
command to run migration is: dotnet ef database update --project dctrly.Infrastructure --startup-project dctrly
it requires EF tools installed

CQRS: Decided to go with MediatR and use it directly (time efficient)

Tests: Went with xUnit, Moq and Shouldly, last one mostly because latest version of FluentAssertion is paid

Some assumptions:
- no many-to-many relationship between events and attendees
- each time someone is invited to event I create completely new record for them
- I tried to put in-code comments whenever something might have not been clear

I use Bruno at home (postman alternative) and I have included collection of test calls