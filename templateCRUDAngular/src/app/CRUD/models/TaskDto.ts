export interface TaskDto {
  TaskId: string;
  TaskName: string;
  Description: string;
}
export interface TaskDetailDto {
  TaskId: string;
  Description: string;
  IsCompleted: boolean;
  DateCreatedString: string;
  DateUpdatedString: string;
}

