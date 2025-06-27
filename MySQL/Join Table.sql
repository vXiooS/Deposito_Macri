--    JOIN TABLE --
SELECT customer.first_name, address.address, city.city, country.country
FROM customer
JOIN address ON address.address_id = customer.address_id
JOIN city ON city.city_id = address.city_id
join country on country.country_id = city.country_id;

select category.name , count(film.film_id)
from film
join film_category on film_category.film_id = film.film_id
join category on category.category_id = film_category.category_id
group by (category.name);

select actor.first_name, actor.last_name , count(film.film_id)
from actor
join film_actor on film_actor.actor_id = actor.actor_id
join film on film.film_id = film_actor.film_id
group by actor.actor_id;


-- Intermedio

-- Mostra il nome del film, la sua categoria e gli attori che vi hanno recitato (usa JOIN multipli).
	select film.title, category.name, actor.first_name, actor.last_name
    from film
    join film_category on film_category.film_id = film.film_id
	join category on category.category_id = film_category.category_id
    join film_actor on film_actor.film_id = film.film_id
	join actor on actor.actor_id = film_actor.actor_id;
    
-- Trova i clienti che hanno effettuato più di 5 noleggi.
	select customer.customer_id ,customer.first_name, customer.last_name, count(rental.rental_id)
    from customer
    join rental on rental.customer_id = customer.customer_id
    group by (rental.customer_id)
    having count(rental.customer_id) > 40;
    
-- Elenca tutti i film che non sono mai stati noleggiati.
	select film.title 
    from film
    join inventory on inventory.film_id = film.film_id
    join rental on rental.inventory_id = inventory.inventory_id
    where rental.return_date is null;
    
--     Avanzato    --

-- Mostra il nome del film, la sua categoria e il totale speso dai clienti per quel film (basato sui noleggi).
	select film.title , category.name, sum(payment.amount)
    from film
    join film_category on film_category.film_id = film.film_id
	join category on category.category_id = film_category.category_id
    join inventory on inventory.film_id = film.film_id
    join rental on rental.inventory_id = inventory.inventory_id
    join payment on payment.rental_id = rental.rental_id
    group by film.title, category.name;
    
-- Trova gli attori che non hanno mai recitato in un film di una determinata categoria (es: 'Action').
	select actor.first_name, actor.last_name, group_concat(category.name separator "/") as Categorie
    from actor
    join film_actor on film_actor.actor_id = actor.actor_id
	join film on film.film_id = film_actor.film_id
    join film_category on film_category.film_id = film.film_id
	join category on category.category_id = film_category.category_id
    group by actor.first_name, actor.last_name
    having categoria not like '%action%';
    
-- Trova le categorie di film con il numero medio di attori più alto per film.    
    select category.name, count(actor.actor_id)/count(distinct film.film_id) as AvgActorPerFilm
    from category
    join film_category on film_category.category_id = category.category_id
    join film on film.film_id = film_category.film_id
    join film_actor on film_actor.film_id = film.film_id
    join actor on actor.actor_id = film_actor.actor_id
    group by category.name;
    
-- **Esercizio 1: Clienti con più di 20 noleggi totali, ordinati per spesa totale decrescente**
-- **Richiesta**
-- Mostra l’`id`, il `nome`, `cognome`, numero totale di noleggi e somma spesa totale per quei clienti che hanno fatto **più di 20 noleggi**. Ordina per somma spesa decrescente.    
    select customer.customer_id, concat(customer.first_name , ' ' , customer.last_name) as customer , count(rental.rental_id) as noleggiotot , sum(payment.amount)
    from customer
    join rental on customer.customer_id = rental.customer_id
    join payment on rental.rental_id = payment.rental_id;
    
     
--   Esercizio 2: Numero medio di noleggi per categoria di film
-- Richiesta:  Calcola il numero medio di noleggi per ogni categoria (category.name). Ordina per media decrescente. Mostra solo categorie con almeno 50 noleggi totali.
-- category.name as categoria ,  count(rental.rental_id)/ count (distinct film.film_id) as media_noleggi
    select category.name as categoria ,  count(rental.rental_id)/ count(distinct film.film_id) as media_noleggi, count(rental.rental_id) as noleggi_tot
    from rental 
    join inventory on inventory.inventory_id = rental.inventory_id
    join film on film.film_id = inventory.film_id
    join film_category on film_category.film_id = film.film_id
    join category  on category.category_id = film_category.category_id
    group by categoria
    having noleggi_tot > 50
    order by media_noleggi desc;
    
--  Esercizio 3: Attori con più film a catalogo e noleggi totali
--  Richiesta: Mostra gli attori che hanno partecipato ad almeno 10 film presenti nell’inventario e il numero totale di noleggi per i film in cui hanno recitato. Ordina per noleggi totali decrescenti.    
	select concat(actor.first_name  , ' ', actor.last_name) as actorname, count(distinct film.film_id) as num_films, count(rental.rental_id) as num_rental
    from actor
    join film_actor on film_actor.actor_id = actor.actor_id
    join film on film.film_id = film_actor.film_id
    join inventory on inventory.film_id = film.film_id
    join rental on rental.inventory_id = inventory.inventory_id
    group by actorname
    having num_films > 10
    order by num_rental desc;
    
    
--   Categorie più "redditizie" per spesa totale media per film
-- Richiesta: Per ogni categoria, mostra la spesa totale media per film (non per noleggio). Ordina per media decrescente. 
	select category.name as categoria, sum(payment.amount)/count(distinct film.film_id) as median_amount
    from category
    join film_category on film_category.category_id = category.category_id
    join film on film.film_id =  film_category.film_id
    join inventory on inventory.film_id = film.film_id
    join rental on rental.inventory_id = inventory.inventory_id
    join payment on payment.rental_id = rental.rental_id
    group by categoria
    order by median_amount desc;
    
    
    -- Left, right  JOINS  --
    INSERT INTO actor (first_name, last_name, last_update)
	VALUES ('Mario', 'Rossi', NOW());
    
    SELECT a.actor_id, a.first_name, a.last_name, f.title
	FROM actor a
	JOIN film_actor fa ON a.actor_id = fa.actor_id
	JOIN film f ON fa.film_id = f.film_id
	WHERE a.first_name = 'Mario';
    
    SELECT a.actor_id, a.first_name, a.last_name, f.title
	FROM actor a
	LEFT JOIN film_actor fa ON a.actor_id = fa.actor_id
	LEFT JOIN film f ON fa.film_id = f.film_id
	WHERE a.first_name = 'Mario';