# 💬 **Dating App Web Application**

The **Dating App** is a modern web application built using **Angular 17** for the frontend and **ASP.NET Core Web API** for the backend. It allows users to register, log in, search for potential matches, engage in real-time messaging, and upload photos to enhance their profiles. The app features **admin role management** and uses **Cloudinary** for seamless photo uploads and storage.

---

## 📝 **Project Overview**

The **Dating App Web Application** is built with two primary modules:

- **User Module**: Users can register, log in, update their profiles, search for potential matches, like other users, view matches, and engage in instant messaging.
- **Admin Module**: Admins can manage user roles and permissions.

---

## 💡 **Key Features**

### **👨‍💻 User Module**

- **🔑 Authentication & Authorization**:
  - Users can **register** and **log in** using **single authentication** via **Identity**.
  - Includes **password recovery** and **account verification** features.
  - **Role-based authorization** (user/admin), allowing admins to manage user roles and permissions.

- **🖼 Profile Management**:
  - Users can **create and update their profiles** by uploading pictures using **Cloudinary** for fast, reliable, and secure image storage.
  - Users can add personal information, such as name, age, interests, bio, and preferences.
  - Profile settings allow users to control visibility and privacy.

- **🔍 Search & Filter**:
  - Users can **search** for potential matches using filters such as **location**, **age**, **interests**, etc.

- **💬 Messaging & Real-Time Communication**:
  - Users can **send messages** and engage in **real-time communication** using **SignalR**.
  - **Instant messaging** with **live updates** enables a seamless user experience.
  - **Online status visibility**: Users can see who is currently online and available for chat.

- **👍 Liking & Matching**:
  - Users can **like** other users, and if both users like each other, a **match** occurs.
  - Users are notified of new matches and can interact with other users they’ve matched with.

- **⚙️ Profile Settings**:
  - Users can manage their **preferences**, including notification settings, visibility, and privacy controls.

### **👨‍💼 Admin Role Management**

- **🛠 Admin Role Management**:
  - Admins have the ability to manage user roles, including **promoting** or **demoting** users and assigning admin privileges.
  - Admins can control users' access to features based on their role.

---

## ⚙️ **Technologies Used**

- **ASP.NET Core 8**: Backend framework to create a secure API with **Identity** for user authentication and authorization, and handling messaging and profile management.
- **Angular 17**: Frontend framework for building a dynamic, responsive, and user-friendly interface.
- **SignalR**: Used for **real-time communication**, enabling live chat updates and instant messaging between users.
- **Cloudinary**: Enables **photo upload** and image storage for user profiles.
- **SQL Database**: Stores user profiles, messages, matches, and other app data.
- **Identity**: Manages user authentication and role-based access control (user/admin).
- **HTML & CSS**: For structuring and styling the web pages.
- **JavaScript**: Enhances interactivity and overall user experience.

---

## 🚀 **Setup Instructions**

### 1. **Clone the Repository**:
```bash
git clone https://github.com/AltinPajaziti/DatingApp.git
