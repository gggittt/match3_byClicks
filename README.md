| [Game rules](#Game-rules) | [TODO](#TODO) | [Архитектура](#Архитектура) |[Naming](#Naming) | [My codestyle](#My-codestyle) |
|---------------------------|---------------|-----------------------------|------------------|-------------------------------|

# match3_byClicks

## В коде точка входа: [_Project/Core/Infrastructure/Bootstrapper.cs](https://github.com/gggittt/match3_byClicks/blob/main/Assets/_Project/Core/Infrastructure/Bootstrapper.cs)

## Game rules
match3 in unity. Initially planning feature not merge items, but click on them


https://github.com/user-attachments/assets/72bb1baa-8e84-4570-87d2-4ba62ee23ed5




## Архитектура
- Притащил систему где храню в Board.CellGrid<Cell>, а не Grid<Item> т.к. она у меня уже была. 
  - Все при всех взаимодействиях "шариков", сначала нахожу ячейку Cell в которой шарик лежит, и беру его уже оттуда. Возможно стоило бы так не делать, и хранить матрицу шариков, без посредника в виде Cells. 

## Реализовано:
- customization: match только в линии, или все соединённые ортогонально (включая угловые повороты)

## Использованные плагины
- Zenject
- DoTween
- TMP

## Использованные паттерны
- FSN
- ObjectsPool
- Observer

## Todo
- Переиспользовать логику states, возможно заменить интерфейсы на абстрактные классы.
- Переиспользовать логику GoToSceneXxxButton ? Подумать.
  - Возможно прямо внутри кнопки (в Inspector, в компонент Button) прокинуть монобех, в котором выбирать методы на какую сцену перейти. ```class SceneSwitcher : MonoBehaviour{public void LoadMainMenu(){} public void LoadLeaderboard(){}...}```
  - Или в моём монобехе выставлять сцену на которую перехожу в enum. Но тогда будет "дубляж сущностей": и в enum и классы отдельных переходов на сцену. 



