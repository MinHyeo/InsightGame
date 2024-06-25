# Github branch naming 규칙
## 이슈에 대한 설명
브랜치 네이밍 규칙을 적용함으로 브랜치 이름을 정형화 한다.

## 브랜치 네이밍 규칙
1. main branch, develop branch
 
* main - 제품으로 출시될 수 있는 브랜치
   
   * 사용자에게 배포 가능한 상태만을 관리한다. 여기서는 배포(release) 이력을 관리하기 위해 사용한다.
 * develop - 다음 출시 버전을 개발하는 브랜치
   
   * 기능 개발을 위해 브랜치들을 병합하기 위해 사용, 즉 모든 기능이 추가되고 버그가 수정되어 배포 가능한 안정적인 상태라면 develop 을 main 으로 병합한다. 평소에는 이 브랜치 기반으로 개발을 진행한다.
 
 2. feature branch
 
 * feature - 새로운 기능 개발 및 버그 수정이 필요할 때마다 develop 브랜치로부터 분기한다.
   
   * 개발이 완료되면 develop 브랜치로 merge 하여 다른 사람들과 공유한다.
   * feature/front/기능요약 ex) feature/front/login, feature/back/login-api
   * feature/front/{issue-number}-기능요약 ex) feature/front/#77-login, feature/back/#77-login-api
 
 3. release branch
 
 * release - 이번 출시 버전을 준비하는 브랜치
   
   * ex) release-1.2
 
 4. hotfix branch
 
 * hotfix - 출시 버전에서 발생한 버그를 수정하는 브랜치
   
   * ex) hotfix-1.2.1
 
 ## 참고사이트
 * https://velog.io/@kim-jaemin420/Git-branch-naming
 * [Github branch naming 규칙 earthkingman/42Swim#86 (comment)](https://github.com/earthkingman/42Swim/issues/86#issue-1027281349)
 
 ## checkList
 1. 주의사항
 
 * feature/기능요약 에서 기능요약 부분을 작성할때 띄어쓰기는 - 를 이용하여 작성
   
   * ex) loginApi (X) login-api (O)
