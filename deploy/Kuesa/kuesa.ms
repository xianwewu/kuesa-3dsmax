fn initKuesa = (
    format "Launching KDAB Kuesa...\n"
    p = getSourceFileName()
    p = substituteString p "\\" "/"
    p = substituteString p "kuesa.ms" "KuesaPython/kuesa.py"
    python.ExecuteFile p
)

fn startUp = (
    unRegisterRedrawViewsCallback startUp
    initKuesa()
)
registerRedrawViewsCallback startUp
