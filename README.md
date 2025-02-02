# **UnitConversion 📏⚡**
*A .NET library for converting between units of measurement such as length, temperature, volume, speed, and more.*

[![NuGet](https://img.shields.io/nuget/v/Treebion.UnitConversion.svg)](https://www.nuget.org/packages/Treebion.UnitConversion/)
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

---

## **📦 Installation**
You can install `UnitConversion` via **NuGet Package Manager** or **.NET CLI**:

### **Using .NET CLI**
```sh
dotnet add package Treebion.UnitConversion
```

### **Using NuGet Package Manager**
```sh
Install-Package Treebion.UnitConversion
```

---

## **📖 Usage**
Here's how you can use `UnitConversion` to convert between different units:

### **1️⃣ Temperature Conversion**
Convert **Celsius to Fahrenheit**:
```csharp
using UnitConversion;

double celsius = 0;
var fahrenheit = new Temperature(celsius, TemperatureUnit.Celsius).To(TemperatureUnit.Fahrenheit);
Console.WriteLine($"{celsius} °C = {fahrenheit.Value} °F");
```

### **2️⃣ Length Conversion**
Convert **meters to miles**:
```csharp
using UnitConversion;

double meters = 1000;
var miles = new Length(meters, LengthUnit.Meter).To(LengthUnit.Mile);
Console.WriteLine($"{meters} meters = {miles.Value} miles");
```

### **3️⃣ Speed Conversion**
Convert **kilometers per hour to miles per hour**:
```csharp
using UnitConversion;

double kmph = 100;
var mph = new Speed(kmph, SpeedUnit.KilometersPerHour).To(SpeedUnit.MilesPerHour);
Console.WriteLine($"{kmph} km/h = {mph.Value} mph");
```

---

## **📌 Supported Units**
✅ **Length:** Meter, Kilometer, Mile, Yard, Foot, Inch

✅ **Temperature:** Celsius, Fahrenheit, Kelvin

✅ **Speed:** Kilometers per Hour, Miles per Hour, Meters per Second

✅ **Volume:** Liter, Milliliter, Gallon, Cubic Meter

And more!

---

## **💡 Contributing**
Contributions are welcome! If you’d like to improve the library, follow these steps:

1. **Fork** the repository.
2. **Clone** your forked repo:
   ```sh
   git clone https://github.com/Treebion/UnitConversion.git
   ```
3. **Create a new branch**:
   ```sh
   git checkout -b feature-new-conversion
   ```
4. **Commit your changes** and **push** the branch.
5. Submit a **Pull Request** (PR) for review.

---

## **📜 License**
This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

---

## **📬 Contact**
📌 **GitHub Repository:** [UnitConversion](https://github.com/Treebion/UnitConversion)

📧 For any inquiries, feel free to reach out!

---

🚀 **Happy Coding!** 🎉

