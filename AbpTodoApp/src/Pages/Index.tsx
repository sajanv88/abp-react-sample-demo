import Main from "@/layouts/Main.tsx";
import {TodoItem} from "@/interfaces/TodoItem.ts";
import {Card, CardContent, CardHeader, CardTitle} from "@/components/ui/card.tsx";
import AddTodo from "@/components/features/AddTodo.tsx";
import UpdateTodo from "@/components/features/UpdateTodo.tsx";
import DeleteTodo from "@/components/features/DeleteTodo.tsx";


export default function Index(props: { todos: Array<TodoItem> }) {

    return (
        <Main>
            <div className="pt-3">
                <div className="flex justify-end py-2">
                    <AddTodo/>
                </div>
                <Card className="w-full">
                    <CardHeader>
                        <CardTitle className="text-2xl">List of todos</CardTitle>
                    </CardHeader>
                    <CardContent className="space-y-4">
                        {props.todos.length === 0 && (
                            <div className="text-center text-gray-500">
                                No todos found
                            </div>
                        )}
                        {props.todos.map((todo) => (
                            <div
                                key={todo.id}
                                className="flex items-center justify-between border-b border-gray-200 transition ease-in last:border-b-0 py-3 px-2 hover:bg-secondary">
                                <div>
                                    <h2 className="text-lg font-semibold">{todo.title}</h2>
                                    <p>{todo.description}</p>
                                </div>
                                <div className="flex flex-col space-y-3">
                                    <UpdateTodo todo={todo}/>
                                    <DeleteTodo todoId={todo.id}/>
                                </div>
                            </div>

                        ))}
                    </CardContent>
                </Card>
            </div>
        </Main>
    )
}