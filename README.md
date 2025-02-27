# 💬 **Dating App Web Application**

**Dating App** is a modern web application built using **Angular** for the frontend and **.NET** for the backend. It provides users with the ability to register, log in, search for potential matches, and engage in real-time communications. The app also includes profile management features and allows users to like other users and see who matches with them.

---

## 📝 **Project Overview**

The **Dating App Web Application** includes two primary modules:

- **User Module**: Users can register, log in, update their profile, search for potential matches, like other users, and see who they match with. They can also communicate with others in real-time.
  

The application uses **Identity** for **authentication** and **authorization**, ensuring secure and seamless user management.

---

## 💡 **Key Features**

### **👨‍💻 User Module**
- **🔑 Authentication & Authorization**:
  - Users can **register** and **log in** using **single authentication** via **Identity**.
  - **Password recovery** and **account verification** are included.
  - **Role-based authorization** (user/admin).
  
- **🖼 Profile Management**:
  - Users can **create and update their profiles** by uploading pictures and adding information such as name, age, interests, etc.
  - Ability to view and update profile information, including a brief bio and preferences.
  
- **🔍 Search & Filter**:
  - Users can **search** for potential matches based on **filters** like location, age, interests, etc.
  
- **💬 Messaging & Real-time Communication**:
  - Users can **send messages** and engage in **real-time communication** with other users.
  - Use **SignalR** for live chat updates.
  
- **👍 Liking & Matching**:
  - Users can **like** other users and see if there is a **match**.
  - Match notifications will be displayed, and users can interact with those they like.
  
- **⚙️ Profile Settings**:
  - Users can modify their **preferences**, including notification settings, visibility, and other privacy settings.



## ⚙️ **Technologies Used**

- **.NET 8**: Backend framework using **ASP.NET Core 8** to create a secure API with **Identity** for user authentication and authorization.
- **Angular 17**: Frontend framework to build a responsive, dynamic, and interactive UI.
- **SQL Database**: Stores user profiles, messages, matches, and other data.
- **SignalR**: Real-time communication for live chats between users.
- **HTML & CSS**: For web page structure and styling.
- **JavaScript**: Adding interactivity and enhancing user experience.

---

## 🚀 **Setup Instructions**

### 1. **Clone the Repository**:
```bash
git clone https://github.com/AltinPajaziti/DatingApp.git
