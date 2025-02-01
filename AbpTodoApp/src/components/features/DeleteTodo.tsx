import {Button} from "@/components/ui/button.tsx";


export default function DeleteTodo(props: {todoId: number}) {
    const { todoId } = props;
    return (
        <form method="post" action={`/delete/${todoId}`}>
            <span className="hidden" dangerouslySetInnerHTML={{__html: window.__RequestVerificationToken}}></span>
            <Button variant="destructive" type="submit">
                Delete
            </Button>
        </form>
    )
}