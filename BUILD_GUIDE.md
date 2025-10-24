# 빌드 가이드

## 개발 환경 빌드

Visual Studio에서 일반적인 개발 및 디버깅용으로 빌드:

```
빌드 > 솔루션 빌드 (Ctrl+Shift+B)
```

또는 F5를 눌러 디버그 모드로 실행


## 배포용 단일 실행 파일 빌드

모든 의존성이 포함된 단일 exe 파일을 생성하려면:

### 방법 1: Visual Studio 사용

1. 상단 메뉴: `빌드` > `구성 관리자`
2. `활성 솔루션 구성`을 `Release`로 변경
3. `솔루션 탐색기`에서 프로젝트 우클릭 > `게시`
4. 대상: 폴더
5. 게시 클릭

### 방법 2: 명령줄 사용

프로젝트 폴더에서 PowerShell 또는 명령 프롬프트를 열고:

```powershell
cd Application
dotnet publish -c Release -r win-x64 --self-contained true
```

빌드된 파일 위치:
```
Application\bin\Release\net6.0-windows\win-x64\publish\ToolKitV.exe
```

## 실행 파일 특징

- 모든 DLL이 하나의 exe에 포함됨
- .NET 런타임 포함 (다른 PC에 .NET 설치 불필요)
- 압축되어 있어 첫 실행 시 압축 해제로 인해 약간의 지연 발생
- 이후 실행은 빠르게 진행됨

## 문제 해결

### 빌드 오류 발생 시

1. .NET 6.0 SDK가 설치되어 있는지 확인
2. Visual Studio 재시작
3. `bin`과 `obj` 폴더 삭제 후 다시 빌드

### DLL 누락 오류 발생 시

Debug 빌드를 사용 중이라면 다음 파일들이 출력 폴더에 있는지 확인:
- Dependencies\texconv.exe
- Dependencies\CodeWalker.Core.dll

Release 빌드(단일 파일)에서는 모든 것이 exe에 포함되어 있습니다.
