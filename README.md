# SolutecHackathon2016Team3
Repository pour l'équipe 3 du hackathon organisé par l'entreprise Solutec

https://draineri.github.io/SolutecHackathon2016Team3/

Projet DreamHacker

## Dream Team

Bastien GUYL, Team leader (and Unity dev)
Jonathan PLATTEAU, Full Stack Badass Dev
Adrien ROMANET, Also Badass Dev, bier manager
Gaetan ROCHE, Useless... And Unity dev
Clement BLAISE, Unity dev and Designer
David, RDF data model Master

### Database
Fuseki Server : http://jena.apache.org/documentation/fuseki2/

just change /run/shino.ini : 
and the rest are restricted to localhost.
"/$/** = anon" instead of  "#/$/** = localhostFilter" to allow update from localNetwork

just change  : 
"#/$/** = localhostFilter" by "/$/** = anon" in /run/shino.ini to allow update from localNetwork

create a dataset named "test"
then upload data to this dataset  from this file : https://github.com/DRaineri/SolutecHackathon2016Team3/blob/master/ontologie/hackathonSolutec.owl



