# 🎯 Design Patterns Playground (.NET)

Este repositorio está diseñado como un entorno de práctica para implementar y probar **patrones de diseño clásicos** usando **C# y .NET**. Incluye un proyecto de consola para las implementaciones y un proyecto de pruebas para validar su comportamiento.

---

## 📁 Estructura del Proyecto



DesignPatternsPlayground/
│
├── DesignPatternsPlayground.sln # Archivo de solución
│
├── DesignPatterns/ # Proyecto principal (implementaciones)
│ ├── Program.cs
│ ├── Creational/
│ │ └── Singleton/
│ │ └── Logger.cs
│ ├── Structural/ # (por agregar)
│ └── Behavioral/ # (por agregar)
│
└── DesignPatterns.Tests/ # Proyecto de pruebas unitarias
└── Creational/
└── Singleton/
└── LoggerTests.cs


---

## 🧱 Patrones implementados

| Tipo         | Patrón     | Estado      |
|--------------|------------|-------------|
| Creational   | Singleton  | ✅ Implementado (`Logger`) |
| Structural   | --         | 🔜 Pendiente |
| Behavioral   | --         | 🔜 Pendiente |

---

## 🧪 Ejecutar pruebas


dotnet test


## Ejecutar EL proyecto
dotnet run --project ./DesignPatterns/
