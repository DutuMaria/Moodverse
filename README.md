# Moodverse


## **Demo**
Demo can be found [here](https://www.youtube.com/watch?v=N7cAEuuBZh8).

---

## **Documentation**
Documentation can be found [here](https://docs.google.com/document/d/1wIn6nfWaczCQ40ZIAO7h8x_K5OlrtVVFI38nepe6frk/edit#heading=h.3085icgq9mqg).

---

## **Team Members**
- [Anghelache Andreea](https://github.com/deeaanghelache)
- [Duțu Maria-Alexandra](https://github.com/DutuMaria)
- [Gîrbea Monica-Andreea](https://github.com/monicaandreea)
- [Sîmpetru Eva-Maria](https://github.com/evasimpetru28)

---
## **Diagrams**

### UML
![](/img/uml_diagram.png)
### Actions
![](/img/state_machine_diagram.png)

---
## **Cerinte proiect**
### A. Implementarea - notă între 1 și 10
- [x] Live demo pentru aplicația dezvoltată.
- [x] În plus, trebuie să salvați un demo offline (în YouTube etc): faceți un screencast (vezi o lista de tooluri pentru screencasturi) înainte de prezentare SAU înregistrați prezentarea cu screensharing făcută laborantului (multe tooluri de remote meeting oferă această opțiune).

### B. Procesul de dezvoltare software - notă între 1 și 10
Acesta constă din următoarele părți:
- [x] user stories (minim 10), backlog creation - **2 pct**
- [x] design/arhitectura/UML - **2 pct**
- [x] source control (branch creation, merge/rebase, minim 10 commits) - **2 pct**
- [x] teste automate (unit sau integration) - minim 5 - **3 pct**
- [x] bug reporting - **1 pct**
- [ ] folosirea unui build tool - **1 pct**
- [x] refactoring (minim 1), code standards - **1 pct**
- [ ] design patterns - **1 pct**

---
### Comenzi migratii

- dotnet ef --startup-project Moodverse --project Moodverse.DAL migrations add UpdatedEntites

- dotnet ef --startup-project Moodverse --project Moodverse.DAL database update