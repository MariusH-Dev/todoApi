# TodoAPI - Einfache und gut dokumentierte API

## 📌 Überblick

Die **TodoAPI** ist ein einfaches, gut dokumentiertes Beispiel einer RESTful API, entwickelt mit **ASP.NET Core**. Sie bietet grundlegende **CRUD-Funktionalitäten** zur Verwaltung von **Aufgaben (ToDos) und Benutzern**. Dieses Projekt demonstriert bewährte Praktiken der API-Entwicklung, einschließlich:

- **Entity Framework Core** mit einer In-Memory-Datenbank
- **Swagger/OpenAPI** für Dokumentation
- **XML-Kommentare** zur API-Dokumentation
- **Standard-HTTP-Methoden** (GET, POST, PUT, DELETE)

---

## 🚀 Funktionen

- 📋 **Aufgabenverwaltung**: Erstellen, Lesen, Aktualisieren und Löschen (**CRUD**)
- 👥 **Benutzerverwaltung**: Basisfunktionen für Benutzer
- 📄 **Swagger UI**: Automatisch generierte API-Dokumentation
- 🔥 **Vollständig dokumentierte API** mit XML-Kommentaren
- ✅ **Einfach und erweiterbar**

---

## 🛠️ Verwendete Technologien

- **C# mit ASP.NET Core Web API**
- **Entity Framework Core** (In-Memory-Datenbank)
- **Swashbuckle** (Swagger-Dokumentation)
- **.NET 7.0 oder höher**

---

## 📂 Projektstruktur

```
TodoAPI/
├── Controllers/
│   ├── TodoController.cs  # Verwaltet Aufgaben
│   ├── UserController.cs  # Verwaltet Benutzer
│
├── Models/
│   ├── TaskItem.cs  # Aufgabenmodell
│   ├── User.cs      # Benutzermodell
│
├── Data/
│   ├── TodoContext.cs  # Datenbankkontext für Entity Framework
│
├── Program.cs         # Hauptkonfiguration der API
├── README.md         # Projektdokumentation
└── TodoAPI.csproj    # Projektkonfiguration
```

---

## 🔧 Einrichtung & Installation

### 1️⃣ Repository klonen

```bash
git clone https://github.com/MariusH-Dev/TodoAPI.git
cd TodoAPI
```

### 2️⃣ Abhängigkeiten installieren

```bash
dotnet restore
```

### 3️⃣ API starten

```bash
dotnet run
```

### 4️⃣ Swagger API-Dokumentation aufrufen

Sobald die API läuft, öffne den Browser und gehe zu:

➡️ **https://localhost:7197/swagger**

Hier kannst du die interaktive **Swagger UI** verwenden, um API-Endpunkte zu testen.

---

## 📌 API-Endpunkte

### 📝 Aufgabenverwaltung

| Methode | Endpoint        | Beschreibung                     |
|---------|-----------------|----------------------------------|
| GET     | /api/Todo       | Alle Aufgaben abrufen            |
| GET     | /api/Todo/{id}  | Aufgabe nach ID abrufen          |
| POST    | /api/Todo       | Neue Aufgabe erstellen           |
| PUT     | /api/Todo/{id}  | Bestehende Aufgabe aktualisieren |
| DELETE  | /api/Todo/{id}  | Aufgabe löschen                  |

### 👥 Benutzerverwaltung

| Methode | Endpoint      | Beschreibung             |
|---------|---------------|--------------------------|
| GET     | /api/User     | Alle Benutzer abrufen    |
| POST    | /api/User     | Neuen Benutzer erstellen |

---

## ⚙️ Swagger-Integration

Swagger ist **automatisch konfiguriert**. Um die API-Dokumentation anzuzeigen, besuche:

➡️ **https://localhost:7197/swagger**

Hier kannst du API-Endpunkte direkt aus dem Browser testen.

---

## 📌 Beispielanfrage & Antwort

### 📌 Neue Aufgabe erstellen

#### **Anfrage (POST /api/Todo)**
```json
{
  "title": "Einkaufen",
  "description": "Milch, Brot, Eier",
  "priority": 2,
  "dueTime": "2024-02-01T18:30:00Z"
}
```

#### **Antwort (201 Created)**
```json
{
  "id": "f13b5fc7-4567-432e-923a-1c76ff7456a6",
  "title": "Einkaufen",
  "description": "Milch, Brot, Eier",
  "priority": 2,
  "state": 0,
  "dueTime": "2024-02-01T18:30:00Z",
  "createdAt": "2024-01-28T12:00:00Z"
}
```

---

## 📜 Lizenz

Dieses Projekt ist **Open Source** und unter der **MIT-Lizenz** verfügbar.

---

## 🎯 Autor

Entwickelt von **MariusH-Dev** - [GitHub-Profil](https://github.com/MariusH-Dev)

---

🚀 Viel Spaß beim Programmieren! 🎉
