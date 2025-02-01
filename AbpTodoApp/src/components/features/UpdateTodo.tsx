import {Checkbox} from "@/components/ui/checkbox.tsx";
import {useRef, useState} from "react";
import {TodoItem} from "@/interfaces/TodoItem.ts";


export default function UpdateTodo(props: { todo: TodoItem }) {
    const formRef = useRef<HTMLFormElement | null>(null);
    const {todo} = props;
    const [isCompleted, setIsCompleted] = useState<boolean>(todo.isCompleted);
    return (
        <form key={todo.id} method="post" action={`/update/${todo.id}`} ref={formRef}>
            <span className="hidden" dangerouslySetInnerHTML={{__html: window.__RequestVerificationToken}}></span>
            <div className="flex items-center space-x-2">
                <input type="hidden" name="isCompleted" value={isCompleted.toString()} />
                <Checkbox id={`completed_${todo.id}`}
                          defaultValue={todo.isCompleted ? 1 : 0}
                          checked={isCompleted}
                          type="submit"
                          onCheckedChange={(checked) => {
                              console.log(checked);
                              if (formRef.current) {
                                  setIsCompleted(checked as boolean);
                              }
                          }}/>
                <label
                    htmlFor={`completed_${todo.id}`}
                    className="text-sm font-medium leading-none peer-disabled:cursor-not-allowed peer-disabled:opacity-70"
                >
                    Mark as completed
                </label>
            </div>
        </form>
    )
}