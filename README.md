
# Observer Pattern Implementation in C#

This project demonstrates the **Observer Pattern** using a news publisher and readers. It showcases how readers can subscribe to news updates and receive notifications whenever new articles are published.

The Observer pattern is a behavioral design pattern that allows an object (called the subject) to maintain a list of its dependents (observers) and notify them of any changes to its state automatically. This pattern is useful for implementing distributed event handling systems and enables a one-to-many dependency between objects.

## Table of Contents

- [Observer Pattern Implementation in C#](#observer-pattern-implementation-in-c)
  - [Table of Contents](#table-of-contents)
  - [Introduction](#introduction)
  - [Technologies Used](#technologies-used)
  - [Features](#features)
  - [Code Explanation](#code-explanation)
    - [Key Methods](#key-methods)
    - [IObservable and IObserver](#iobservable-and-iobserver)

## Introduction

The Observer Pattern is a behavioral design pattern where an object (known as the subject) maintains a list of its dependents (observers) and notifies them automatically of any state changes. In this project, a `NewsPublisher` acts as the subject, and readers act as observers that receive updates about news articles.

## Technologies Used

- C# (.NET 8 or higher)
- Console Application

## Features

- Readers can subscribe and unsubscribe from the news publisher.
- The publisher notifies subscribed readers when new news articles are published.


## Code Explanation

- `NewsPublisher`: The main class responsible for managing subscriptions and notifying observers (readers) about news updates.
- `Reader`: Represents the subscriber. Each reader can subscribe to or unsubscribe from the news publisher.
- `IObservable` & `IObserver`: The built-in interfaces in C# used to implement the Observer Pattern.

### Key Methods

- **PublishNews(string news)**: Publishes a news article and notifies all subscribed readers.
- **Subscribe(IObserver observer)**: Allows a reader to subscribe to the news publisher.
- **Unsubscribe(IObserver observer)**: Allows a reader to unsubscribe from the news publisher.

```plaintext
+--------------------------------------------+
|   NewsPublisher                            |
+--------------------------------------------+
| - observers: List<IObserver<string>>       |
+--------------------------------------------+
| + Subscribe(observer: IObserver<string>)   |
| + Unsubscribe(observer: IObserver<string>) |
| + PublishNews(news: string)                |
+--------------------------------------------+
```

```plaintext
+------------------------------+
|   Reader                     |
+------------------------------+
| - name: string               |
+------------------------------+
| + OnNext(news: string)       |
| + OnError(error: Exception)  |
| + OnCompleted()              |
+------------------------------+
```

### IObservable<T> and IObserver<T>

```plaintext
+---------------------------------------+
|   IObservable<T>                      |
+---------------------------------------+
| + Subscribe(observer: IObserver<T>)   |
| + Unsubscribe(observer: IObserver<T>) |
+---------------------------------------+

+------------------------------+
|   IObserver<T>               |
+------------------------------+
| + OnNext(value: T)           |
| + OnError(error: Exception)  |
| + OnCompleted()              |
+------------------------------+
```
