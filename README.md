# Rapport Ontwikkeling van een eerste Agent

## Inleiding
Dit rapport gaat over het trainen van een AI agent in Unity. Het doel is om een blauwe kubus te leren hoe hij eerst een target moet pakken en die daarna naar een groene lijn moet brengen. Ik onderzoek hoe de agent leert van zijn omgeving en hoe aanpassingen aan de sensoren en bewegingen invloed hebben op hoe slim hij wordt.

---

## Methoden
De agent is gemaakt met de Unity ML Agents toolkit versie 0.30.0 en getraind met het PPO algoritme.

### Primaire Componenten
* Behaviour parameters: Dit is de verbinding tussen Unity en het brein van de AI.
* Agent CubeAgent.cs: Dit is het script dat alles regelt. De agent heeft een Ray Perception Sensor 3D om objecten te zien met stralen die zoeken naar de tags Target en Finish.

### Override Methods
* OnEpisodeBegin: Deze methode start alles opnieuw op. De agent gaat terug naar het midden en de target krijgt een nieuwe plek. Ook de status of hij de target vastheeft gaat terug op false.
* CollectObservations: Hier vertelt de agent aan zijn brein of hij de target al heeft opgepakt of niet. Dat is heel belangrijk voor de keuze die hij daarna moet maken.
* OnActionReceived: Dit zorgt ervoor dat de agent echt kan bewegen. Hij kan vooruit gaan en om zijn as draaien. Ook worden hier de punten uitgedeeld voor het raken van de target of de lijn.
* Heuristic: Hiermee kan ik zelf met het toetsenbord rijden om te kijken of de target en de lijn wel goed reageren op de agent.

---

## Resultaten
Ik heb verschillende trainingen gedaan en dit is wat ik ben tegengekomen:

In mijn eerste training zag de agent er wat verdwaald uit. Dit kwam omdat ik de ray perceptors te breed had gemaakt. Hij kon uiteindelijk de target wel vinden en terugbrengen maar dit duurde veel te lang omdat hij te veel informatie tegelijk kreeg.

Bij mijn tweede poging heb ik de ray perceptors nauwer gemaakt voor meer focus. Maar toen was het probleem dat hij enkel recht voor zich kon kijken. De target die soms achter hem verscheen kon hij niet zien. Omdat hij in deze versie nog niet kon draaien zag hij de target nooit en was hij maar wat doelloos aan het rondbewegen op het platform.

Daarna heb ik ervoor gezorgd dat hij kon draaien terwijl hij bewoog. Toen kreeg ik het probleem dat hij steeds in rondjes draaide en de target precies per ongeluk oppakte. De agent leek hierdoor wel een stuk actiever. De finishlijn kon hij na het oppakken van de target wel elke keer goed vinden. De score in de grafieken ging hierdoor ook langzaam omhoog omdat hij steeds vaker de hele reeks afmaakte.

---

## Conclusie
Ik concludeer dat de agent het beste leert als hij kan rondkijken. In het begin lijkt het alsof hij maar wat doet door rondjes te draaien maar dat is hoe hij de target probeert te vinden in zijn gezichtsveld. De agent begrijpt nu het verschil tussen de fase waarin hij de target zoekt en de fase waarin hij naar de finish moet. Het draaien was echt nodig om de blinde vlekken op te lossen.

---

## Referenties
* Unity Technologies 2022. ML Agents Toolkit Documentation. Geraadpleegd via de officiële GitHub pagina.
* Knappe 2020. Voor de basis van hoe Reinforcement Learning werkt in een 3D omgeving.