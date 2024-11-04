# MindboxTestTask
## Russian (Русский)
> [!NOTE]  
> Данный репозиторий - **тестовое задание для ООО Mindbox** на позицию C# developer
> 
>**⭐ Поставьте хотя бы звездочку 😢**

## Инструкция по использованию
### Добавление новой геометрической фигуры
1. Необходимо отнаследоваться от [`Shape`](https://github.com/Ivanplat/MindboxTestTask/blob/main/FiguresCalculationLibrary/Base/Shape.cs);
2. Реализуйте абстрактные методы ```cs double CalculateSquare()``` и ```cs void Initialize<T>(T args)```;
3. Создайте фабрику для нового класса, наследуемую от [`ShapeFactory`](https://github.com/Ivanplat/MindboxTestTask/blob/main/FiguresCalculationLibrary/Factories/ShapeFactory.cs);
4. Пользуйтесь методом фабрики ```cs CreateShape(ArgsType args)``` из созданной фабрики;
5. Радуемся :)