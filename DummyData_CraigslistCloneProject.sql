select * from Threads
select * from Listings
select * from AspNetUsers

insert into Threads ( Title, Description, Created ) values ( 'Computers', 'For all of your pc needs', GETDATE() )
insert into Threads ( Title, Description, Created ) values ( 'Cars', 'For all of your car needs', GETDATE() )
insert into Threads ( Title, Description, Created ) values ( 'Toys', 'For all of your toy needs', GETDATE() )
insert into Threads ( Title, Description, Created ) values ( 'Sports', 'For all of your sports needs', GETDATE() )
insert into Threads ( Title, Description, Created ) values ( 'Jobs', 'For all of your employment needs', GETDATE() )

-- Create a user or this insert will not work
insert into Listings ( Title, Content, Created, Expires, UserId, hostThreadId )
values ( 'Gaming PC', 'Single core processor + gtx 560 + 5 ram', GetDate(), GetDate(), '59833c68-2b89-47ca-96b8-4b1eb7fae4d5', 1 )

