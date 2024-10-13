| [Game rules](#Game-rules) | [TODO](#TODO) | [Архитектура](#Архитектура) |[Naming](#Naming) | [My codestyle](#My-codestyle) |
|---------------------------|---------------|-----------------------------|------------------|-------------------------------|

# match3_byClicks

## В коде точка входа: 
  1) [_Project/Core/Infrastructure/Bootstrapper.cs](https://github.com/gggittt/match3_byClicks/blob/main/Assets/_Project/Core/Infrastructure/Bootstrapper.cs)
  2) далее на геймплей сцене: [_Project/Core/EntryPointGameplay.cs](https://github.com/gggittt/match3_byClicks/blob/main/Assets/_Project/Core/EntryPointGameplay.cs)

## Game rules
match3 in unity. Initially planning feature not merge items, but click on them


https://github.com/user-attachments/assets/72bb1baa-8e84-4570-87d2-4ba62ee23ed5




## Архитектура
- Притащил систему где храню в Board.CellGrid<Cell>, а не Grid<Item> т.к. она у меня уже была. 
  - Все при всех взаимодействиях "шариков", сначала нахожу ячейку Cell в которой шарик лежит, и беру его уже оттуда. Возможно стоило бы так не делать, и хранить матрицу шариков, без посредника в виде Cells. 

## Реализовано:
- customization: match только в линии, или все соединённые ортогонально (включая угловые повороты)
- ячейки создаются в runtime. до начала игры в объекте GameData можно настроить размер поля

## Использованные плагины
- Zenject
- DoTween
- TMP

## Использованные паттерны
- FSN
- ObjectsPool
- Observer
- EntryPoint
- Factory

## Todo
- центрировать камеру в runtime под поле. 
- вынести в конфиги настройки (из [SerializeField] монобехов):
  - размер поля
  - очки за комбо
  - очки для победы
- Переиспользовать логику states, возможно заменить интерфейсы на абстрактные классы.
- Переиспользовать логику GoToSceneXxxButton ? Подумать.
  - Возможно прямо внутри кнопки (в Inspector, в компонент Button) прокинуть монобех, в котором выбирать методы на какую сцену перейти. ```class SceneSwitcher : MonoBehaviour{public void LoadMainMenu(){} public void LoadLeaderboard(){}...}```
  - Или в моём монобехе выставлять сцену на которую перехожу в enum. Но тогда будет "дубляж сущностей": и в enum и классы отдельных переходов на сцену. 

## My codestyle
- Не делаю отступ для namespace. Не вижу смысла. Заранее готов с фиче C# 10 "File scoped namespaces", когда отступ не будет нужен. Тем программистам, кто всё время делал отступ, полагаю будет непривычно, когда отступ исчезнет. 
  - ![image](https://github.com/user-attachments/assets/e503d46c-a8ec-4009-8409-00aec11e9a11)
  - Настраивается в Rider: убрать галочку здесь:
  - ![image](https://github.com/user-attachments/assets/23592106-de71-4c76-bc93-52338fa2f64d)
  - Возможно стоит добавить _Project в "no namespace provider". А может и нет, т.к. тогда появляется вероятность что мои namespaces Будут конфликтовать с namespaces внешних плагинов
- Не пишу очевидный private
- prefer Type over var
- внутри круглых скобок пишу пробелы. 
  настраивается здесь:
  - ![image](https://github.com/user-attachments/assets/f30c82c2-1481-474f-85e8-2c03fae9bd2c)
- consts - PascalCase, even for private and local. Не вижу смысла в SNAKE_CASE, это просто замедляет печать. ![image](https://github.com/user-attachments/assets/4da2d2ed-2648-4eae-aeed-97b34347e98c)
<!-- - [Inject] в поля, не только в Construct() -->

- в остальном +- стандартно.
  - Возможно позже перейду с ```ctor(int some){ _some = some; }``` to ```ctor(int some){ this.some = some; }```
 




