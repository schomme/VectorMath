# Übungsaufgabe C# / .NET / WPF
 Mathematik der 3D-Vektoren

## Inhalt
- Vector WPF Demo
- VectorLib
- VectorTest

## Anhängigkeiten
[Helix-Toolkit](https://github.com/helix-toolkit/helix-toolkit)

## Fragen & Anworten

### 1. Implementierung des 3D-Vektors als Klasse oder als Struktur?
_Um mit dem Vector möglichst flexibel arbeiten zu können, wurde sich für eine Klasse entschieden. Die Vector Klasse befindet sich in einer Bibliothek. Daher sollten Eigenschaften wie Vererb- und Veränderbarkeit erhalten bleiben._

### Soll der Vektor nach seiner Erzeugung unveränderlich sein oder sollen sich seine Komponenten nachträglich ändern lassen?
_Die Komponenten dürfen sich nachträglich verändern, da die abhängigen Eigenschaften wie "Länge" sich automatisch anpassen._

### In welcher Art und Weise erfolgt die Prüfung auf Gleichheit und Ungleichheit? Überladen Sie die entsprechenden Operatoren oder nicht?
_Dabei muss unterschieden werden ob geprüft werden soll, ob es sich um das selbe Objekt handelt oder ob zwei Vektoren identisch sind (gleich Orientierung, gleiche Länge, gleiche Richtung).
Für die Bibliothek wurde entschieden, dass gepüft werden soll ob es sich um das selbe Objekt handelt.
Dafür wurden die Equals und Hashcode Methode überschrieben._

### Wie wird der Hashcode eines Vektors bestimmt
_Da der Hashcode für zwei Vektoren, die die selben Komponenten haben, gleich ist, muss eine zusätzliche Komponente einfließen.
Dafür wird jedem Vektor eine GUID zugwiesen, die jeden Hashcode einzigartig macht es sei denn es handelt sich um das selbe Objekt.
Dadurch lassen sich z.B. zwei Vektoren definieren mit den selben Komponenten und in einem Hashset speichern._