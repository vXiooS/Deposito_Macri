-- Livello 3 — Filtri speciali: IN, BETWEEN, LIKE, IS NULL
-- Trova i film che hanno rating tra 'PG' e 'R'.
	select title, rating from film where rating between 'pg' and 'r';
-- Visualizza i film con rating 'G', 'PG' o 'PG-13'.
	select title, rating from film where rating in ("G","PG", "PG-13");
-- Mostra i film che iniziano con la parola 'THE'.
	select title from film where title like "the%"; 
-- Visualizza i clienti il cui nome inizia con 'A'.
	select * from customer where first_name like "a%";
-- Trova tutti i noleggi (rental) in cui la data di ritorno (return_date) è NULL.
	select * from rental where return_date is null;
    select * from rental where rental_date is null;

--       Livello 4 — ORDER BY, LIMIT, DISTINCT
-- Visualizza i primi 10 film ordinati per durata decrescente.
	select * from film order by length desc limit 10;
-- Mostra i 5 clienti più recenti in base alla data di creazione (create_date).
	select * from customer order by create_date limit 5;
-- Visualizza tutti i rating distinti dei film presenti nel database.
	select distinct rating from film; 
-- Trova gli importi unici presenti nella tabella payment, ordinati dal più alto al più basso.
	select distinct amount from payment order by amount;
-- Visualizza i 3 film più lunghi il cui rating è 'PG-13'.
	select * from film where rating like 'pg-13' order by length desc limit 3;
    
--     Livello 1 — Funzioni di base su testo
-- Mostra il titolo (title) di tutti i film e la lunghezza del titolo (numero di caratteri).
-- Uso di LENGTH(title)
	select title, length(title) as nameLength from film; 
-- Visualizza il nome e il cognome (first_name, last_name) di tutti i clienti scritti in maiuscolo.
-- Uso di UPPER(first_name) e UPPER(last_name)
	select Upper(first_name), upper(last_name) from customer; 
-- Visualizza i primi 10 film con il titolo in minuscolo.
-- Uso di LOWER(title) con LIMIT    
	select lower(title) from film order by title limit 10;
    
--     Livello 2 — Manipolazione di stringhe
-- Mostra per ogni film una colonna con il titolo completo in formato: "Titolo (Rating)"
-- Uso di CONCAT(title, ' (', rating, ')') AS titolo_completo
	select concat (title, ' (', rating, ')') AS titolo_completo from film;
-- Mostra i primi 10 caratteri del titolo di ogni film.
-- Uso di LEFT(title, 10)
	select left(title, 3) from film;
-- Visualizza gli ultimi 5 caratteri del titolo per i primi 10 film.
-- Uso di RIGHT(title, 5)
	select right(title, 5) from film;
-- Mostra una colonna con le prime 3 lettere del cognome di ogni cliente.
-- Uso di LEFT(last_name, 3)
	select left (last_name, 3) from customer;
-- Estrai e mostra la seconda parola del titolo nei film che iniziano con 'THE' (solo per chi vuole usare SUBSTRING o LOCATE).    
	select substring_index(title, ' ', -1) as SecondWord 
    from film where title like 'lost %';
    
    /* LOCATE(substr, str)
Restituisce la posizione della prima occorrenza della sottostringa substr nella stringa str. Se non trova nulla, restituisce 0. */

SELECT title, LOCATE('DOG', title) AS posizione_dog
FROM film
WHERE LOCATE('DOG', title) > 0;

-- TROVARE DOVE SI TROVA IL CARATTERE "A" NEL NOME DEGLI ATTORI --
SELECT first_name, last_name, LOCATE('A', first_name) AS posizione_a
FROM actor
WHERE LOCATE('A', first_name) > 0;
-- SUBSTRING(string, start, length) // SUBSTRING(string FROM start FOR length) --

-- ESTRARRE I PRIMI 5 CARATTERI DEI TITOLI --
SELECT title, SUBSTRING(title, 1, 5) AS primi_cinque
FROM film;

-- Estrarre l'ultima parte del cognome --
SELECT last_name, SUBSTRING(last_name, LENGTH(last_name) - 2, 3) AS ultimi_tre
FROM actor
WHERE LENGTH(last_name) >= 3;

-- LOCATE + SUBSTRING – estrarre tutto dopo “AT” nel titolo --
SELECT
title,
SUBSTRING(title, LOCATE('AT ', title) + 3) AS dopo_at
FROM film
WHERE LOCATE('AT ', title) > 0;


-- Cerca l’ultimo spazio (con REVERSE) e ricava da lì la ultima parola. --
SELECT
title,
SUBSTRING(title, LENGTH(title) - LOCATE(' ', REVERSE(title)) + 2) AS ultima_parola
FROM film
WHERE title LIKE '% %';


    
--    Livello 3 — Funzioni su date
-- Mostra tutti i clienti con la loro data di creazione e la data attuale.
-- Uso di CURDATE() o NOW()
	select *, curdate(), now() from customer; 
-- Calcola quanti giorni sono passati dalla creazione del cliente ad oggi.
-- Uso di DATEDIFF(CURDATE(), create_date)
	select *, curdate(), datediff(curdate(), create_date) from customer;
-- Visualizza l’anno in cui ogni cliente è stato creato.
-- Uso di YEAR(create_date)
	select * , year(create_date) from customer;
-- Mostra tutti i noleggi (rental) effettuati nel 2005.
-- Uso di YEAR(rental_date) = 2005
	select * from rental where year(rental_date) = 2005;
-- Visualizza i primi 10 clienti e quanti giorni fa si sono registrati.
-- DATEDIFF(NOW(), create_date) AS giorni_registrato    
	select *, DATEDIFF(NOW(), create_date) AS giorni_registrato from customer limit 10;
    
    
-- Conta quanti film sono presenti nella tabella film.
	select count(*) from film;
-- Calcola la durata media (length) di tutti i film.
	select avg(length) from film;
-- Trova la durata minima e massima dei film.
	select max(length) as maxlength, min(length) as minlength from film;
-- Calcola la somma totale di tutti i pagamenti (amount) nella tabella payment.
	select sum(amount) from payment;
    
--    GROUP BY base
-- Conta quanti film ci sono per ciascun rating (rating).
	select count(film_id), rating from film group by (rating);
-- Calcola la durata media dei film per ciascun rating.
	select avg(length), rating from film group by (rating);
-- Mostra il numero totale di pagamenti effettuati da ciascun cliente (customer_id).
	select count(customer_id), customer_id from payment group by(customer_id);
-- Calcola l'importo totale pagato da ciascun cliente (customer_id).
	select sum(amount), customer_id from payment group by(customer_id);
-- Trova il numero di film disponibili per ciascuna lunghezza (length).
    select count(film_id), length from film group by (length) order by length desc; 
    
--     Filtri con HAVING e ROUND su AVG()
-- Mostra i rating con una durata media dei film superiore a 100 minuti.
	select rating from film group by(rating) having avg(length) > 100;
-- Elenca solo i clienti che hanno pagato in totale più di 100€.
	select customer_id from payment group by(customer_id) having sum(amount) > 100;
-- Trova i rating in cui sono presenti almeno 50 film.
	select rating from film group by (rating) having count(film_id) > 200;
-- Mostra per ciascun rating la durata media dei film, arrotondata a 1 decimale.
	select rating, round(avg((length))) from film group by(rating); 
-- Mostra i clienti che hanno effettuato più di 10 pagamenti.
	select customer_id from payment group by (customer_id) having count(customer_id) > 10;