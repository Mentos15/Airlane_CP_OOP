
select flights.id_flight, date_from, date_to,s1.town[от куда], s2.town[куда],company_name ,count_of_seats-count_of_customers, class, case class when 'Бизнес' 
then cast(route.length_of_route*company.cost_of_1km + company.cost_of_business as int) else cast(route.length_of_route*company.cost_of_1km + company.cost_of_econom as int)
end Стоимость from   flights inner join route 
on flights.route = route.id_route inner join airport s1  on s1.nameAirport = route.id_airport_from  inner join  airport s2 on s2.nameAirport = route.id_airport_to
inner join company on flights.company = company.company_name  inner join  aircrafts on flights.aircraft = aircrafts.name_aircraft


update users set userPassword = 'ewqewq' where 'e' = users.userLogName



select userLogName, Surname,Name, date_from,date_to, s1.town,s2.town, id_ticket from  tickets inner join users on tickets.id_customer = users.userId 
                inner join flights on tickets.id_flight = flights.id_flight inner join route on flights.route = route.id_route  inner join airport s1  on s1.nameAirport = route.id_airport_from 
                 inner join  airport s2 on s2.nameAirport = route.id_airport_to





select flights.id_flight, date_from[Дата вылета], date_to[Дата прилета],s1.town[от куда], s2.town[куда],company_name[Название компании]  ,count_of_seats[количество мест], class, case class when 'Бизнес' 
then cast(route.length_of_route*company.cost_of_1km + company.cost_of_business as int) else cast(route.length_of_route*company.cost_of_1km + company.cost_of_econom as int)
end Стоимость from   flights inner join route 
on flights.route = route.id_route inner join airport s1  on s1.nameAirport = route.id_airport_from  inner join  airport s2 on s2.nameAirport = route.id_airport_to
inner join company on flights.company = company.company_name  inner join  aircrafts on flights.aircraft = aircrafts.name_aircraft 

select userLogName, Surname,Name, date_from,date_to, s1.town,s2.town, id_ticket, price from  tickets inner join users on tickets.id_customer = users.userId 
                inner join flights on tickets.id_flight = flights.id_flight inner join route on flights.route = route.id_route  inner join airport s1  on s1.nameAirport = route.id_airport_from 
                 inner join  airport s2 on s2.nameAirport = route.id_airport_to


select * from company

select * from flights
select * from route
select * from aircrafts
select * from users
select * from airport
select * from tickets
select id_route,s1.town,s2.town,length_of_route from route   inner join airport s1  on s1.nameAirport = route.id_airport_from 
                 inner join  airport s2 on s2.nameAirport = route.id_airport_to


select date_from,id_airport_from ,id_airport_to, company, price, class from flights inner join  route on flights.route = route.id_route inner join tickets on  tickets.id_flight = flights.id_flight 

select userLogName, Surname,Name, date_from,date_to, s1.town,s2.town, id_ticket,price from  tickets inner join users on tickets.id_customer = users.userId 
                inner join flights on tickets.id_flight = flights.id_flight inner join route on flights.route = route.id_route  inner join airport s1  on s1.nameAirport = route.id_airport_from 
                 inner join  airport s2 on s2.nameAirport = route.id_airport_to

