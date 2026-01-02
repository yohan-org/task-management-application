import { Pipe, PipeTransform } from '@angular/core';
import { TaskItemDto } from '../models/task-item-dto';

@Pipe({ name: 'taskSort', standalone: true })
export class TaskSortPipe implements PipeTransform {

  transform(
    tasks: TaskItemDto[] | null,
    sortBy: keyof TaskItemDto | null
  ): TaskItemDto[] {

    if (!tasks || !sortBy) return tasks ?? [];

    return [...tasks].sort((a, b) => {
      const aValue = a[sortBy] ?? '';
      const bValue = b[sortBy] ?? '';

      const aComparable =
        typeof aValue === 'boolean' ? Number(aValue) : aValue;
      const bComparable =
        typeof bValue === 'boolean' ? Number(bValue) : bValue;

      return aComparable > bComparable
        ? 1
        : aComparable < bComparable
        ? -1
        : 0;
    });
  }
}
