import {Card, CardContent} from "@/components/ui/card.tsx";
import Main from "@/layouts/Main.tsx";

export default function Error(props: { message: string, code: number }) {
    const {message, code} = props;
    return (
        <Main>
            <div className="pt-5">
                <Card>
                    <CardContent className="p-5">
                        <div className="text-center text-red-500">
                            <h1 className="text-3xl font-semibold">Error: {code}</h1>
                            <p className="text-lg">{message ?? "An error occurred while processing your request."}</p>
                        </div>
                    </CardContent>
                </Card>
            </div>
        </Main>
    )
}