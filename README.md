# MindboxTestTask
## Russian (Русский)
> [!NOTE]  
> Данный репозиторий - **тестовое задание для ООО Mindbox** на позицию C# developer
> 
>**⭐ Поставьте хотя бы звездочку 😢**

## Инструкция по использованию
### Добавление новой геометрической фигуры
1. Необходимо отнаследоваться от [`Shape`](https://github.com/Ivanplat/MindboxTestTask/blob/main/FiguresCalculationLibrary/Base/Shape.cs);
2. Реализуйте абстрактные методы 
```csharp
 double CalculateSquare()
```
```csharp
 void Initialize<T>(T args)
```

3. Создайте фабрику для нового класса, наследуемую от [`ShapeFactory`](https://github.com/Ivanplat/MindboxTestTask/blob/main/FiguresCalculationLibrary/Factories/ShapeFactory.cs);
4. Пользуйтесь методом из созданной фабрики 
```csharp
 Shape CreateShape(ArgsType args)
 ```
5. Радуемся :)

Например:

```csharp

/*Трапеция*/
public sealed class Trapezoid : Shape
{
    private double[] segments_ = null!;

    public override double CalculateSquare()
    {
        return SquareFromAllSegments();
    }

    private double SquareFromAllSegments()
    {
        double underRootValue = ((segments_[1]-segments_[0])* (segments_[1]-segments_[0]) + segments_[2]*segments_[2]-segments_[3]*segments_[3])/(2*(segments_[1]-segments_[0]));
        return (segments_[0]+segments_[1])/2*Math.Sqrt(segments_[2]-(underRootValue*underRootValue));
    }

    public override void Initialize<T>(T args)
    {
        ...
        ...
        ...
    }
    ...
    ...
    ...
}

/*Фабрика*/
public class TrapezoidFactory : ShapeFactory<Trapezoid, double[]>
{
    ...
    ...
    ...
}

/*Использование*/
TrapezoidFactory factory = new();
var trapezoid = factory.CreateShape(new double[]{10, 20, 30, 40});
Console.WriteLine(trapezoid.CalculateSquare());
```
В данном примере была использована следующая формула:
<img src="https://otvet.imgsmail.ru/download/68976796_9e345726eb672e2e143241a45cfd5f04_800.jpg" />

## English 
> [!NOTE]  
> This repository is **test task for OOO Mindbox** for the position of C# developer
> 
>**⭐ Please give at least one star 😢**

## Instructions for use
### Adding a new geometric shape
1. Inherite from [`Shape`](https://github.com/Ivanplat/MindboxTestTask/blob/main/FiguresCalculationLibrary/Base/Shape.cs);
2. Implement abstract methods
```csharp
 double CalculateSquare()
```
```csharp
 void Initialize<T>(T args)
```

3. Create a factory for the new class that inherits from [`ShapeFactory`](https://github.com/Ivanplat/MindboxTestTask/blob/main/FiguresCalculationLibrary/Factories/ShapeFactory.cs);
4. Use the method from the created factory 
```csharp
 Shape CreateShape(ArgsType args)
 ```
5. Have fun :)

For example:

```csharp

/*Trapezoid*/
public sealed class Trapezoid : Shape
{
    private double[] segments_ = null;

    public override double CalculateSquare()
    {
        return SquareFromAllSegments();
    }

    private double SquareFromAllSegments()
    {
        double underRootValue = ((segments_[1]-segments_[0])* (segments_[1]-segments_[0]) + segments_[2]*segments_[2]-segments_[3]*segments_[3])/(2*(segments_[1]-segments_[0]));
        return (segments_[0]+segments_[1])/2*Math.Sqrt(segments_[2]-(underRootValue*underRootValue));
    }

    public override void Initialize<T>(T args)
    {
        ...
        ...
        ...
    }
    ...
    ...
    ...
}

/*Factory*/
public class TrapezoidFactory : ShapeFactory<Trapezoid, double[]>
{
    ...
    ...
    ...
}

/*Usage*/
TrapezoidFactory factory = new();
var trapezoid = factory.CreateShape(new double[]{10, 20, 30, 40});
Console.WriteLine(trapezoid.CalculateSquare());
```
