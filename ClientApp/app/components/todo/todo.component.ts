import { Component } from '@angular/core'; 
import { Http } from '@angular/http';

@Component({
    selector: 'todo',
    template: require('./todo.component.html')
})

export class TodoComponent {
    public tasks: TodoTask[];

    constructor(http: Http) {
        http.get('/api/Todo/TodoTasks').subscribe(result => {
            this.tasks = result.json();
        });
    }
}

interface TodoTask {
    taskName: string; 
    deadline: string;
}

