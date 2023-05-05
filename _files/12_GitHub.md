## 12. Verzovací systémy

### Git
* distribuovaný verzovací systém
* neukládá se seznam změn, ale tzv. **snapshot**
* => snímek všech nových a změněných souborů a odkazy na tyto soubory

### GitHub
* **poskytovatel** služby Git na webu
* alternativy: GitLab, BitBucket, ...

### Repozitář
* datové úložiště verzovacího systému pro daný projekt
* **lokální** - offilne, v úložišti uživatele
* **vzdálený** - online, nahraný na GitHub

### Commit
* **uložení změn (lokálně)**
* aby se změny projevily i ve vzdáleném repozitáři, je nutné je **pushnout**

### Větev
* posloupnost commitů daného projektu
* lze je **spojovat (merge)**
* myšlenka - **hlavní větev (master/main)** je část kódu připravená ke **zveřejnění**
* testování nových funkcí by se mělo odehrávat v jiné větvi
* **spojení - merge, může dojít ke konfliktu (kolize) - nutné vyřešit**

### Základní příkazy
* https://www.freecodecamp.org/news/10-important-git-commands-that-every-developer-should-know/
* git clone <REPOSITORY_URL>
* git branch <branch-name>
* git push -u <remote> <branch-name>
* git checkout <name-of-your-branch>
* git status
* git add <file>
* git commit -m "commit message"
* git push <remote> <branch-name>
* git pull <remote>
* git revert 3321844
* git merge <branch-name>