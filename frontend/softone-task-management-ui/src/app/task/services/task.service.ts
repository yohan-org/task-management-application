// src/app/tasks/services/task.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaskItemDto } from '../../shared/models/task-item-dto';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private apiUrl = 'https://localhost:5001/api/tasks'; // update with your .NET API URL

  constructor(private http: HttpClient) {}

  /** Get all tasks */
  getTasks(): Observable<TaskItemDto[]> { debugger
    return this.http.get<TaskItemDto[]>(this.apiUrl);
  }

  /** Get single task by id */
  getTaskById(id: number): Observable<TaskItemDto> {
    return this.http.get<TaskItemDto>(`${this.apiUrl}/${id}`);
  }

  /** Add a new task */
  addTask(task: TaskItemDto): Observable<TaskItemDto> {
    return this.http.post<TaskItemDto>(this.apiUrl, task);
  }

  /** Update an existing task */
  updateTask(task: TaskItemDto): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${task.id}`, task);
  }

  /** Delete a task */
  deleteTask(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

  /** Toggle completion status */
  toggleComplete(task: TaskItemDto): Observable<void> {
    const updatedTask = { ...task, isCompleted: !task.isCompleted };
    return this.updateTask(updatedTask);
  }
}
