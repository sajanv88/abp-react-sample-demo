import {Button} from "@/components/ui/button.tsx";
import {
    Dialog,
    DialogContent,
    DialogDescription,
    DialogFooter,
    DialogHeader,
    DialogTitle,
    DialogTrigger,
} from "@/components/ui/dialog"
import {Input} from "@/components/ui/input"
import {Label} from "@/components/ui/label"
import {Textarea} from "@/components/ui/textarea.tsx";

export default function AddTodo() {

    return (
        <Dialog>
            <DialogTrigger asChild>
                <Button>
                    + Add todo
                </Button>
            </DialogTrigger>
            <DialogContent className="sm:max-w-screen-sm">
                <DialogHeader>
                    <DialogTitle>Create a todo item</DialogTitle>
                    <DialogDescription>
                        Add a new todo item to the list
                    </DialogDescription>
                </DialogHeader>
                <form method="post" action={"/create"}>
                    <span className="hidden" dangerouslySetInnerHTML={{__html: window.__RequestVerificationToken}}></span>
                    <div className="grid gap-4 py-4">
                        <div className="grid grid-cols-4 items-center gap-4">
                            <Label htmlFor="name" className="text-right">
                                Title
                            </Label>
                            <Input id="title" placeholder="Learn ABP framework" name="title" className="col-span-3"/>
                        </div>
                        <div className="grid grid-cols-4 items-center gap-4">
                            <Label htmlFor="username" className="text-right">
                                Description
                            </Label>
                            <Textarea id="description" className="col-span-3" name="description" />
                        </div>
                    </div>
                    <DialogFooter>
                        <Button type="submit">Save</Button>
                    </DialogFooter>
                </form>
            </DialogContent>
        </Dialog>

    )
}