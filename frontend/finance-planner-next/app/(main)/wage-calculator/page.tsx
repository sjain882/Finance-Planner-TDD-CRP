'use client'

import { WageCalculatorForm } from "./components/form";
import { Dialog, DialogContent, DialogTitle } from "@/components/ui/dialog"
// import { VisuallyHidden } from "@/components/ui/visually-hidden"
import { useEffect, useRef } from "react"

export default function WageCalculator() {
    const open = true

    const dialogRef = useRef<HTMLDivElement>(null)
    useEffect(() => {
        dialogRef.current?.focus()
    }, [])

    return (
        <Dialog open={open}>
            <DialogContent
                ref={dialogRef}
                style={{ width: "820px", maxWidth: "90vw", height: "auto", maxHeight: "80vh" }}
                className="p-8 flex flex-col gap-8 outline-none"
                tabIndex={-1}
            >
                {/* <VisuallyHidden> */}
                    <DialogTitle>Wage Calculator</DialogTitle>
                {/* </VisuallyHidden> */}
                <WageCalculatorForm />
            </DialogContent>
        </Dialog>
    )
}

