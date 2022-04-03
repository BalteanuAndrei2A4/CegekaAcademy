# Tema

### Add Car
- adaugati textbox-uri si pentru celelalte campuri (discount, image)
- dupa salvarea cu succes vom directiona inapoi spre pagina _/caroffers_
- adaugati un buton in pagina *Cars* numit *Add car*. Butonul va directiona catre _/newcar_

### Customers
- Afisati in pagina *Customers* lista de clienti sub forma de tabel(Nume, Email). _Hint: puteti folosi bootstrap tables_
- Adaugati un buton *Add customer*. Butonul va directiona spre o pagina _/newcustomer_ unde avem posibilitatea de a adauga un client nou(similar cu pagina de adaugare masini)

### Buy Car
- Adaugati functionalitate butonului de *Buy* de pe o masina
- Click pe *Buy* va directiona spre alta pagina sau va afisa un popup(la alegerea voastra)
- In ecranul de *Buy* vom selecta Clientul care cumpara masina si cantitatea
- Daca introducem o cantitate mai mare decat stocul disponibil afisam o eroare si nu permitem cumpararea
- Rezultatul final va fi generarea unui *Order*

## Bonus

### Customers
- In tabelul Customers numele clientului va fi de tip link. Link-ul va directiona catre o pagina _/customers/{customerId}_
- In noua pagina vom afisa Numele si Email-ul clientului in read-only
- Dedesubt vom afisa un tabel cu toate masinile cumparate de acel client

  _Exemplu:_
  
  **Ion Popescu**
  
  ionpopescu@gmail.com
  
  | Car | Date | Price |
  |-----|------|-------|
  | Dacia Logan | 21 March 2022 | 5000eur|
  | Dacia Sandero | 21 March 2021 | 4000eur|
  ....

