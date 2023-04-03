<h1>Задание 1</h1>
<p>Поля таблицы:</p>

![design_1](https://user-images.githubusercontent.com/35968157/229619185-cf566b19-12fa-4078-b612-6d30d8baac72.png)
![design_2](https://user-images.githubusercontent.com/35968157/229619202-091c58ef-df79-42e8-b69a-be759bbb4204.png)


<br/>
<h2>Запрос 1</h2>
<p>Сотрудник с максимальной заработной платой.</p>

```
SELECT [Employee].*
FROM [dbo].[Employee]
WHERE Salary = (SELECT MAX(Salary) FROM Employee)
```

<p>Результат: </p>

![design_query_1_result](https://user-images.githubusercontent.com/35968157/229619333-92811f6e-47d9-4af9-8e48-d0a6e2916a67.png)

<br/>
<h2>Запрос 2</h2>
<p>Вывести одно число: максимальную длину цепочки руководителей по таблице сотрудников (вычислить глубину дерева).</p>

```
WITH tree (Id , Chief_Id , level)
	AS (SELECT e.Id, e.Chief_ID, 0
		FROM Employee e
		WHERE e.Chief_Id is NULL
		UNION ALL
		SELECT e.Id, e.Chief_Id, level + 1
		FROM Employee e
		INNER JOIN tree tr
		ON (e.Chief_Id = tr.Id )
	)

SELECT MAX(level) as level
FROM tree
```

<p>Результат: </p>

![design_query_2_result](https://user-images.githubusercontent.com/35968157/229619555-2faca9f4-01f0-4118-b8dc-a530875cbe70.png)

<br/>
<h2>Запрос 3</h2>
<p>Отдел, с максимальной суммарной зарплатой сотрудников.</p>

```
WITH Max_Salary_Depr AS
	(SELECT d.name, SUM(e.salary) AS Sum_Salary
	 FROM Employee e JOIn
		  Department d
	 ON e.Department_Id = d.ID
	 GROUP BY d.name)

SELECT [Max_Salary_Depr].*
FROM Max_Salary_Depr
WHERE Max_Salary_Depr.Sum_Salary = (SELECT MAX(Sum_Salary) FROM Max_Salary_Depr)
```

<p>Результат: </p>

![design_query_3_result](https://user-images.githubusercontent.com/35968157/229620713-dee7a370-ce12-49af-9e2b-302522c7c1b2.png)

<br/>
<h2>Запрос 4</h2>
<p>Cотрудника, чье имя начинается на «Р» и заканчивается на «н».</p>

```
SELECT [Employee].*
FROM [dbo].[Employee]
WHERE Name LIKE 'Р%н'
```

<p>Результат: </p>

![design_query_4_result](https://user-images.githubusercontent.com/35968157/229620747-39f62f4d-fe04-4c3a-a514-ba2e0a7d7252.png)
