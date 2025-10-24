# 시바서버 텍스처 최적화

FiveM 시바서버 전용 텍스처 최적화 도구입니다. 600명 이상의 개인 스킨을 관리하면서 발생하는 16MB+ 스트리밍 오류를 **품질 저하 없이** 해결합니다.

[Discord 참여하기](https://discord.gg/VzHq5ysheb) 🎮

---

## 핵심 개선사항 ⭐

### 기존 프로그램의 문제점
- ❌ 최적화 후 스킨이 찰흙처럼 변함
- ❌ 화질이 심각하게 저하됨
- ❌ 2048x1024 → 1024x512로 해상도 절반 감소

### 이 버전의 해결책
- ✅ **품질 유지 알고리즘**: 밉맵 최적화 개선으로 디테일 보존
- ✅ **스마트 최적화**: 불필요한 재압축 방지
- ✅ **적절한 기본값**: 해상도 축소 OFF, 기준값 2048

**결과:**
- 기존: 75% 용량 감소 + 심각한 품질 저하 😱
- 개선: **20-40% 용량 감소 + 최소한의 품질 저하** ✨
- **스킨 품질을 유지하면서도 16MB 스트리밍 오류 해결!**

---

## 다운로드

[Releases 페이지](https://github.com/Jeong-Ryeol/ToolKitV/releases)에서 최신 버전을 다운로드하세요.

단일 실행 파일로 제공되며, .NET 설치 없이 바로 실행 가능합니다.

---

## 사용 방법

### 기본 사용법
1. **텍스처 폴더 선택**: 스킨 .ytd 파일들이 있는 폴더
2. **백업 폴더 선택** (선택사항): 원본 파일 백업 위치
3. **최적화 버튼 클릭**: 자동으로 최적화 진행

### 권장 설정
- ✅ **16MB 이상 파일만 최적화**: 체크 (스트리밍 오류 파일만 처리)
- ❌ **해상도 축소**: 체크 해제 (품질 유지)
- ❌ **포맷 강제 최적화**: 체크 해제 (품질 유지)
- **최적화 기준값**: 2048 (기본값, 적절한 수준)

### 분석 vs 최적화
- **분석 버튼**: 파일을 수정하지 않고 통계만 확인 (미리보기)
- **최적화 버튼**: 실제로 파일을 수정하여 최적화

---

## 빌드 방법

Windows에서 Visual Studio 또는 PowerShell 사용:

```powershell
cd Application
dotnet publish -c Release -r win-x64 --self-contained true
```

빌드된 파일 위치:
```
Application\bin\Release\net6.0-windows\win-x64\publish\ToolKitV.exe
```

자세한 내용은 [BUILD_GUIDE.md](BUILD_GUIDE.md)를 참고하세요.

---

## 기술적 개선사항

### 1. 품질 보존 알고리즘
**밉맵 최적화 개선:**
```csharp
// 개선 전: 너무 공격적 (품질 저하)
int optimalLevel = Math.Max(1, maxLevel - 1);

// 개선 후: 보수적 최적화 (품질 유지)
int optimalLevel = Math.Max(1, maxLevel - 2);
```

**스마트 재압축:**
```csharp
// 변경이 필요 없으면 건드리지 않음
bool needsRecompression = resolutionChanged || mipmapNeedsUpdate || formatOptimization;
if (!needsRecompression) return texture;
```

### 2. 시바서버 브랜딩
- 모든 UI 한글화
- 시바서버 Discord 링크 통합
- 크레딧 및 오류 메시지 한글화

### 3. 배포 개선
- 단일 exe 파일 (모든 DLL 포함)
- .NET 런타임 포함 (별도 설치 불필요)
- 업데이터 없이 직접 실행 가능

---

## 문제 해결

### 실행이 안 되는 경우
1. **Windows Defender 차단**: 예외 추가 또는 "추가 정보" → "실행" 클릭
2. **첫 실행이 느림**: 압축 해제 과정으로 정상 (1-2초)
3. **관리자 권한 필요**: 우클릭 → "관리자 권한으로 실행"

### 최적화 후에도 스트리밍 오류 발생
1. **최적화 기준값 낮추기**: 2048 → 1024
2. **"16MB 이상만" 체크 해제**: 모든 파일 최적화
3. **Discord 문의**: [discord.gg/VzHq5ysheb](https://discord.gg/VzHq5ysheb)

### 품질이 여전히 낮아지는 경우
- "해상도 축소" 옵션이 체크되어 있는지 확인 (꺼야 함)
- "포맷 강제 최적화" 옵션 체크 해제
- 백업 폴더 지정해서 원본과 비교

---

## 기능

### 현재 기능
- ✅ 텍스처 최적화 (품질 유지)
- ✅ 16MB+ 파일 필터링
- ✅ 백업 기능
- ✅ 실시간 진행률 표시
- ✅ 상세 통계 제공

### 향후 계획
- 🔄 차량 최적화/변환 도구
- 🔄 의상 변환 도구 (replace → add-on)
- 🔄 의상 메타 에디터

---

## 요구사항

- Windows 10/11 (x64)
- .NET 6.0 런타임 포함 (별도 설치 불필요)

---

## 크레딧

이 프로젝트는 [UmbrellaRE/ToolKitV](https://github.com/UmbrellaRE/ToolKitV)를 기반으로 시바서버 환경에 맞게 개선한 버전입니다.

### 오픈소스 라이브러리
- **dexyfex** - [CodeWalker](https://github.com/dexyfex/CodeWalker) (GTA5 파일 처리)
- **blattersturm** - [FiveM](https://github.com/citizenfx/fivem) 업데이터 코드
- **Microsoft** - [texconv](https://github.com/microsoft/DirectXTex) (텍스처 변환)

### 개발
- 원본 개발: Umbrella.RE
- 시바서버 커스터마이징: Jeong-Ryeol

---

## 연락처

- **Discord**: [discord.gg/VzHq5ysheb](https://discord.gg/VzHq5ysheb)
- **GitHub**: [github.com/Jeong-Ryeol/ToolKitV](https://github.com/Jeong-Ryeol/ToolKitV)

---

## 라이선스

이 프로젝트는 원본 ToolKitV의 라이선스를 따릅니다.
