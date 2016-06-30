# SolutecHackathon2016Team3
Repository pour l'équipe 3 du hackathon organisé par l'entreprise Solutec

trello : https://trello.com/invite/dreamcatcher9/0d7ac0913489ede4d2d289832ef12151

https://draineri.github.io/SolutecHackathon2016Team3/

Projet DreamHacker

## Dream Team

* Bastien GUYL, Team leader (and Unity dev)
* Jonathan PLATTEAU, Full Stack Badass Dev
* Adrien ROMANET, Also Badass Dev, bier manager
* Gaetan ROCHE, Useless... And Unity dev
* Clement BLAISE, Unity dev and Designer
* David FAVERIS, RDF data model Master

trello : https://trello.com/invite/dreamcatcher9/0d7ac0913489ede4d2d289832ef12151

### Pourquoi utiliser l'artillerie du Web Sémantique et du [RDF](https://fr.wikipedia.org/wiki/Resource_Description_Framework) pour stocker la taille des box et caillous ?

- pour l'ouverture des données :  interconnexion avec d'autres bases de connaissance ([DBPedia](http://fr.dbpedia.org/page/Lyon), [RDFINSEE](http://rdf.insee.fr/)...)
- pour l'interopérabilité (RDF= xml amélioré !)
- pour [l'inférence](http://www-igm.univ-mlv.fr/~dr/XPOSE2009/Le%20Web%203.0/concepts.html#inference) (déduction d'informations qui ne sont pas explicitement décrites ) --> données prêtes pour le Machine Learning ou une IA
- simplicité pour l'utilisateur qui gère l'info sous forme de triplet (mais complexité pour le dév !)
- pas de schéma prédéfini, scalable... --> on y gagne en agilité !


[plus d'infos sur le RDF](http://www.yoyodesign.org/doc/w3c/rdf-mt/)


### Installation Database
Fuseki Server : http://jena.apache.org/documentation/fuseki2/ ou http://smag0.blogspot.fr/p/blog-page_14.html

just change /run/shino.ini : 
and the rest are restricted to localhost.
"/$/** = anon" instead of  "#/$/** = localhostFilter" to allow update from localNetwork

just change  : 
"#/$/** = localhostFilter" by "/$/** = anon" in /run/shino.ini to allow update from localNetwork

create a dataset named "test"
then upload data to this dataset  from this file : https://github.com/DRaineri/SolutecHackathon2016Team3/blob/master/ontologie/hackathonSolutec.owl



