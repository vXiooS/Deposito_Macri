 -- SUBQUERY --
    select title, length
    from film
    where length > (
		select avg(length)
        from film
		);
    
    select f.title , actor_count
    from (
		select fa.film_id, count(*) as actor_count
        from film_actor as fa
        group by fa.film_id
		)
    as film_actor_count
    join film as f on film_actor_count.film_id = f.film_id
    order by actor_count desc;
    
--    tutti i film che hanno un rental rate maggiore della media del rental rate stesso
    select title, rental_rate
    from film
	where (rental_rate) > (
		select avg(rental_rate)
        from film
		)
    order by rental_rate;    
	
    -- Elenca i nomi e cognomi degli attori che hanno recitato in almeno un film della categoria "Action".
	select concat(first_name , ' ', last_name) as actor_name
    from actor
    WHERE actor_id IN (
		select distinct fa.actor_id 
        from film_actor as fa
        join film on film.film_id = fa.film_id
        join film_category on film_category.film_id  = film.film_id
        join category on category.category_id = film_category.category_id
        WHERE category.name = 'Action'
		);
        
    -- Traccia:
-- Trova i titoli dei film che hanno lo stesso numero di attori del film "ACADEMY DINOSAUR". 
    Select f.title, actor_count
	from (
		select fa.film_id, count(*) as actor_count
        from film_actor as fa
        group by fa.film_id
		)
    as film_actor_count
    join film as f on film_actor_count.film_id = f.film_id
    where actor_count =(
		select count(*) as actor_count
        from film_actor as fa 
        join film f2 on f2.film_id = fa.film_id
        where f2.title = "ACADEMY DINOSAUR"
		)
    order by actor_count desc;
    

	SELECT c.name, COUNT(fc.film_id) AS num_film
	FROM category c
	JOIN film_category fc ON c.category_id = fc.category_id
	GROUP BY c.category_id
	HAVING COUNT(fc.film_id) > (
		SELECT AVG(film_count)
		FROM (
			SELECT COUNT(*) AS film_count
			FROM film_category
			GROUP BY category_id
		) AS sub
	);

-- Trova i clienti che hanno speso più della media delle spese totali dei clienti.
	SELECT c.customer_id, concat(c.first_name,' ', c.last_name)as customer, SUM(p.amount) AS total_spent
    from customer c
    join payment p on c.customer_id = p.customer_id
    group by c.customer_id
	HAVING total_spent > (
			select avg (s.totSp)
            from(
				select sum(amount) as totSp
                from payment
                group by customer_id
			) as s
    )order by total_spent desc;        
    
-- Trova i titoli dei film che non sono mai stati noleggiati.
	SELECT title
    from film f    
	WHERE film_id NOT IN(
		select distinct i.film_id
        from inventory i
       -- join rental r on r.inventory_id = i.inventory_id
       -- where r.rental_date is not null
    );

-- trova tutti i film noleggiati da un determinato customer
	-- not solved
    select c.customer_id, concat(c.first_name,' ', c.last_name)as customer, group_concat(distinct f.title separator "/") as films
    from customer c 
    join payment p on c.customer_id = p.customer_id
    join rental r on r.rental_id = p.rental_id
    join inventory i on  i.inventory_id = r.inventory_id
    join film f on f.film_id = i.film_id
    group by c.customer_id , customer
    having c.customer_id = ( 
		 select c2.customer_id
         from customer c2
         where c2.customer_id = 8
	);
    
 -- Trova i film che hanno la durata più lunga per ogni categoria
	select f.title , f.length , c.name as categoria
    from film f
    join film_category fc on fc.film_id = f.film_id
    join category c on c.category_id = fc.category_id
		where f.length = (
			select max(f2.length)
            from film f2
            join film_category fc2 on fc2.film_id = f2.film_id
            where fc2.category_id = fc.category_id
        )
     order by categoria;   
    

-- trova gli attori i cui film sono stati noleggiati di meno della media dei noleggi per tutti gli attori
	select concat(a.first_name,' ', a.last_name) as actorname, count(r.rental_id) as rentals
    from actor a 
    join film_actor fa on fa.actor_id = a.actor_id
    join film f on f.film_id = fa.film_id
    join inventory i on i.film_id = f.film_id
    join rental r on r.inventory_id = i.inventory_id
		group by actorname
        having rentals < (
			select count(r.rental_id)/count(distinct a.actor_id)
            from actor a 
			join film_actor fa on fa.actor_id = a.actor_id
			join film f on f.film_id = fa.film_id
			join inventory i on i.film_id = f.film_id
			join rental r on r.inventory_id = i.inventory_id
		);
    

-- Trova i paesi in cui clienti noleggiano più film rispetto alla media degli altri paesi, in aggiunta anche il numero totale di clienti in ciascun paese.
	select co.country as paese, count(distinct c.customer_id) as country_customers, count(r.rental_id) as country_rentals 
    from customer c
    join rental r on r.customer_id = c.customer_id
    join address a on a.address_id = c.address_id
    join city on city.city_id = a.city_id
    join country co on co.country_id = city.country_id
		group by paese
        having country_rentals > (
			select count(r2.rental_id)/count(distinct co2.country_id)
            from rental r2
            join customer c2 on c2.customer_id = r2.customer_id
            join address a2 on a2.address_id = c2.address_id
			join city city2 on city2.city_id = a2.city_id
			join country co2 on co2.country_id = city2.country_id
        );
		
-- Trova i titoli dei film e il loro rental_rate che hanno un costo di noleggio (rental_rate) superiore al rental_rate medio di tutti i film che appartengono alla stessa categoria di rating        
    select f.title, f.rental_rate, f.rating
	from film as f
	where f.rental_rate > (
        select avg(f2.rental_rate)
        from film as f2
        where f2.rating = f.rating
    ) order by f.rating, f.title;