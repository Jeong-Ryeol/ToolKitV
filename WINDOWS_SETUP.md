# Windows 환경 설정 가이드

## 1단계: .NET 6.0 SDK 설치 (필수)

https://dotnet.microsoft.com/download/dotnet/6.0

- "Download .NET 6.0 SDK (v6.0.xxx) - Windows x64" 다운로드
- 설치 파일 실행
- 설치 후 CMD에서 확인: `dotnet --version`

## 2단계: Visual Studio 2022 설치 (권장)

https://visualstudio.microsoft.com/ko/downloads/

- "Community 2022" 버전 다운로드 (무료)
- 설치 시 워크로드 선택:
  - ✅ .NET 데스크톱 개발
  - ✅ 유니버설 Windows 플랫폼 개발
- 용량: 약 10GB

## 3단계: Git 설치

https://git-scm.com/download/win

- "Download for Windows" 클릭
- 기본 설정으로 설치

## 4단계: 프로젝트 클론

```cmd
cd C:\
git clone https://github.com/Jeong-Ryeol/ToolKitV.git
cd ToolKitV
```

## 5단계: Visual Studio에서 열기

1. Visual Studio 2022 실행
2. "프로젝트 또는 솔루션 열기"
3. `C:\ToolKitV\ToolKitV.sln` 선택

## 6단계: 빌드

- 상단 메뉴: "빌드" → "솔루션 빌드" (또는 Ctrl+Shift+B)
- 빌드 성공하면 Application/bin/Debug/net6.0-windows/ 폴더에 실행 파일 생성

## 7단계: 실행

- F5 키 (디버그 모드)
- 또는 Ctrl+F5 (일반 실행)

## 간단한 방법 (VS Code 사용 시)

Visual Studio 대신 VS Code 사용하려면:

1. VS Code 설치: https://code.visualstudio.com/
2. .NET 6.0 SDK 설치 (위 1단계)
3. VS Code에서 프로젝트 폴더 열기
4. C# Extension 설치
5. 터미널에서:
   ```cmd
   cd Application
   dotnet build
   dotnet run
   ```

## 문제 발생 시

### "SDK를 찾을 수 없습니다"
- .NET 6.0 SDK 재설치
- Windows 재부팅

### "CodeWalker.Core.dll을 찾을 수 없습니다"
- Dependencies 폴더 확인
- 폴더가 비어있으면 Git LFS 설치 필요

### "texconv.exe 오류"
- Application/Dependencies/texconv.exe 존재 확인
- 없으면 수동 다운로드: https://github.com/microsoft/DirectXTex/releases

## 최소 사양

- Windows 10/11
- RAM: 4GB 이상
- 디스크: 15GB 여유 공간
- 인터넷 연결 (첫 빌드 시 NuGet 패키지 다운로드)
