export default function Main({children}: {children: React.ReactNode}) {
    return (
        <main className="container mx-auto max-w-screen-lg">
            <div className="grid grid-rows-[auto_1fr_auto] h-svh">
                <header className="border-b border-primary py-10">
                    <h1 className="text-2xl font-semibold text-center">A simple ABP todo application</h1>
                </header>

                <div>
                    {children}
                </div>

                <footer className="border-t border-primary py-10">
                    <p className="text-center text-gray-500 dark:text-gray-400">© 2025</p>
                </footer>
            </div>
        </main>
    )
}