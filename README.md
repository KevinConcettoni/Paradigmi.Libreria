# Progetto Libreria Unicam
Progetto svolto per l'esame di Paradigmi di Programmazione dell'Università di Camerino. Il progetto si prefigge di realizzare una web API che permetta la gestione di un catalogo di una libreria utilizzando strumenti quali ASP.NET Core e Entity Framework Core. Le funzionalità presenti all'interno delle API sono: 
 - Creazione di un utente (anonima senza autenticazione)
 - Autenticazione
 - Creazione di una Categoria
 - Eliminazione di una Categoria 
 
 - Caricamento di un libro
 - Modifica di un libro
 - Eliminazione di un libro
 - Ricerca di un libro in base alle seguenti proprietà :
     - Categoria
	  - Nome del libro
	  - Data di Pubblicazione
	  - Autore
# Avvio del porgetto
Per avviare il progetto, una volta scaricato, sarà necessario:
  - Ripristinare il Database utilizzando il dump prensente all'interno del repository. 
  - Cambiare la stringa di connessione (nel file appsettings.json presente all'interno dell'assembly Paradigmi.Libreria.Web)
  - Avviare il progetto
  - Effettuare la registrazione di un nuovo utente
  - Effettuare il login con le credenziali appena create
  - Inserire il token jwt generato dopo il login

A questo punto si ha accesso a tutte le funzionalittà del progetto. 
