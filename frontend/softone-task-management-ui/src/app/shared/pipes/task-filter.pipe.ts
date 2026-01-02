import { Pipe, PipeTransform } from '@angular/core';
import { TaskItemDto } from '../models/task-item-dto';

@Pipe({ name: 'taskFilter' })
export class TaskFilterPipe implements PipeTransform {
  transform(tasks: TaskItemDto[], filterText: string): TaskItemDto[] {
    if (!filterText) return tasks;
    return tasks.filter(t => t.title.toLowerCase().includes(filterText.toLowerCase()));
  }
}
